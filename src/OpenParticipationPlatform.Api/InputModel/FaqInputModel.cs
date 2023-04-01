namespace OpenParticipationPlatform.Api.InputModel
{
    public class FaqInputModel
    {
        public Guid Id { get; set; }

        public Guid MapObjectId { get; set; }

        public string? Question { get; set; }

        public string? Answer { get; set; }

        public bool Published { get; set; }
    }
}
