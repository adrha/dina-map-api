using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenParticipationPlatform.Api.Dbo
{
    public class UrlDbo
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(MapObject))]
        public Guid MapObjectId { get; set; }

        public virtual MapObjectDbo? MapObject { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
