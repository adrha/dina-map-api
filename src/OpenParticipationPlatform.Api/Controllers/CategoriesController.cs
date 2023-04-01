using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenParticipationPlatform.Api.InputModel;
using OpenParticipationPlatform.Api.OutputModel;
using OpenParticipationPlatform.Api.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenParticipationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BasicDataRepository dataRepository;
        private readonly IMapper mapper;

        public CategoriesController(BasicDataRepository dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, type: typeof(List<CategoryViewModel>))]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await dataRepository.GetAllCategoriesAsync();
                var mapped = mapper.Map<List<CategoryViewModel>>(categories);
                return Ok(mapped);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
