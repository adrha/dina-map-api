using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace OpenParticipationPlatform.Api.OutputModel
{
    public class GeoJsonModel
    {
        public class Feature
        {
            public string type { get; set; } = "FeatureCollection";
            public object geometry { get; set; }
            public Properties properties { get; set; }
        }

        public class Properties
        {
            public string name { get; set; }
            public object description { get; set; }
            public string categoryShortName { get; set; }
            public Url[] urls { get; set; }
        }

        public class Url
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
        }
    }
}
