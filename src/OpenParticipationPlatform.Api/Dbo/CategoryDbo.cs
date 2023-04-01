using System.ComponentModel.DataAnnotations;

namespace OpenParticipationPlatform.Api.Dbo
{
    public class CategoryDbo
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string ShortName { get; set; }

        public string? Description { get; set; }

        public bool CanUserAddObject { get; set; }

        [Required]
        public string MapGeometry { get; set; }

        public string? CategoryColor { get; set; }
    }
}
