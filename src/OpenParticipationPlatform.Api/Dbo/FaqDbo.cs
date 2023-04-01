using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenParticipationPlatform.Api.Dbo
{
    public class FaqDbo
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(MapObject))]
        public Guid MapObjectId { get; set; }

        public virtual MapObjectDbo? MapObject { get; set; }

        [Required]
        public string Question { get; set; }

        public string Answer { get; set; }

        public bool Published { get; set; }
    }
}
