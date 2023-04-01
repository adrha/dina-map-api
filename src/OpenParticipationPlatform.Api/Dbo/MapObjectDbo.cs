using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenParticipationPlatform.Api.Dbo
{
    public class MapObjectDbo
    {
        public Guid? Id { get; set; }

        public DateTime? ActiveFrom { get; set; }

        public DateTime? ActiveTo { get; set;}

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string? GeometryData { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        public virtual CategoryDbo? Category { get; set; }

        public virtual List<UrlDbo>? Urls { get; set; }

        public virtual List<FaqDbo>? Faqs { get; set; }
    }
}
