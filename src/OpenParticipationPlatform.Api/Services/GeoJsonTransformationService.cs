using AutoMapper;
using Newtonsoft.Json;
using OpenParticipationPlatform.Api.Dbo;
using OpenParticipationPlatform.Api.OutputModel;
using OpenParticipationPlatform.Api.Repository;
using System.Dynamic;

namespace OpenParticipationPlatform.Api.Services
{
    public class GeoJsonTransformationService
    {
        private readonly IMapper mapper;

        public GeoJsonTransformationService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public GeoJsonModel.Root ConvertDbDataToGeoJsonObject(List<MapObjectDbo> mapObjects)
        {
            var geojsonRoot = new GeoJsonModel.Root();
            geojsonRoot.type = "FeatureCollection";
            geojsonRoot.features = new List<GeoJsonModel.Feature>();

            foreach (var mapobject in mapObjects)
            {
                geojsonRoot.features.Add(new GeoJsonModel.Feature
                {
                    properties = mapper.Map<GeoJsonModel.Properties>(mapobject),
                    geometry = JsonConvert.DeserializeObject<ExpandoObject>(mapobject.GeometryData),
                    type = "Feature"
                });
            }
            return geojsonRoot;
        }
    }
}
