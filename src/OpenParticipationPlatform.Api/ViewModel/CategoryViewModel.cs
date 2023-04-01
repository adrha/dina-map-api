using System.ComponentModel.DataAnnotations;

namespace OpenParticipationPlatform.Api.OutputModel
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string? ShortName { get; set; }

        public string? Description { get; set; }

        public bool CanUserAddObject { get; set; }

        public string? MapGeometry { get; set; }

        public string? CategoryColor { get; set; }
    }
}
