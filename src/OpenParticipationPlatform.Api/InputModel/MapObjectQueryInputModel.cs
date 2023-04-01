namespace OpenParticipationPlatform.Api.InputModel
{
    public class MapObjectQueryInputModel
    {
        public string? CategoryShortNames { get; set; }

        public double? LatStart { get; set; }
        public double? LatEnd { get; set; }
        public double? LongStart { get; set; }
        public double? LongEnd { get; set; }
    }
}
