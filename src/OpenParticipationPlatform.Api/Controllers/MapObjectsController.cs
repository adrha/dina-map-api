using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenParticipationPlatform.Api.Dbo;
using OpenParticipationPlatform.Api.InputModel;
using OpenParticipationPlatform.Api.OutputModel;
using OpenParticipationPlatform.Api.Repository;
using OpenParticipationPlatform.Api.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace OpenParticipationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapObjectsController : ControllerBase
    {
        private readonly BasicDataRepository dataRepository;
        private readonly GeoJsonTransformationService geoJsonTransformationService;
        private readonly IMapper mapper;

        public MapObjectsController(BasicDataRepository dataRepository, GeoJsonTransformationService geoJsonTransformationService, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.geoJsonTransformationService = geoJsonTransformationService;
            this.mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, type: typeof(GeoJsonModel.Root))]
        public async Task<IActionResult> GetMapObjectsAsync([FromQuery] MapObjectQueryInputModel inputModel)
        {
            try
            {
                string[]? categories = null;
                if (inputModel != null && inputModel.CategoryShortNames != null)
                {
                    categories = inputModel.CategoryShortNames.Split(',');
                }
                
                var mapobjects = await dataRepository.GetAllMapObjectsAsync(categories);
                var geojson = geoJsonTransformationService.ConvertDbDataToGeoJsonObject(mapobjects);

                return Ok(geojson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        //[HttpPost]
        //[SwaggerResponse(statusCode: 201, type: typeof(MapObjectViewModel))]
        //public async Task<IActionResult> CreateMapObjectAsync([FromBody] MapObjectInputModel inputModel)
        //{
        //    try
        //    {
        //        var mappedIn = mapper.Map<MapObjectDbo>(inputModel);
        //        var dbOut = await dataRepository.CreateMapObjectAsync(mappedIn);
        //        var mappedOut = mapper.Map<MapObjectViewModel>(dbOut);
        //        return Created($"api/MapObjects/{dbOut.Id.Value}", mappedOut);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut("{mapObjectId}")]
        //[SwaggerResponse(statusCode: 204, type: typeof(MapObjectViewModel))]
        //public async Task<IActionResult> UpdateMapObjectAsync(Guid mapObjectId, [FromBody] MapObjectInputModel inputModel)
        //{
        //    try
        //    {
        //        var mappedIn = mapper.Map<MapObjectDbo>(inputModel);
        //        await dataRepository.UpdateMapObjectAsync(mapObjectId, mappedIn);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }            
        //}


        [HttpGet("{mapObjectId}/urls")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<UrlViewModel>))]
        public async Task<IActionResult> GetAllUrlsOfMapObjectAsync(Guid mapObjectId)
        {
            try
            {
                var faqs = await dataRepository.GetAllUrlsOfMapObjectAsync(mapObjectId);
                var mapped = mapper.Map<List<UrlViewModel>>(faqs);
                return Ok(mapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{mapObjectId}/faqs")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<UrlViewModel>))]
        public async Task<IActionResult> GetAllFaqsOfMapObjectAsync(Guid mapObjectId)
        {
            try
            {
                bool filterOnlyPublished = false;
                var faqs = await dataRepository.GetAllFaqsOfMapObjectAsync(mapObjectId, filterOnlyPublished);
                var mapped = mapper.Map<List<FaqViewModel>>(faqs);
                return Ok(mapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
