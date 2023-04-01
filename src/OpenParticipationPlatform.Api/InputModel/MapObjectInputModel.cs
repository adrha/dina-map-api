using OpenParticipationPlatform.Api.OutputModel;

namespace OpenParticipationPlatform.Api.InputModel
{
    public class MapObjectInputModel
    {
        public Guid Id { get; set; }

        public DateTime? ActiveFrom { get; set; }

        public DateTime? ActiveTo { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid CategoryId { get; set; }

        public string? WktData { get; set; }
    }
}
