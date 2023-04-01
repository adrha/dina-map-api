using OpenParticipationPlatform.Api.Dbo;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenParticipationPlatform.Api.OutputModel
{
    public class FaqViewModel
    {
        public Guid Id { get; set; }

        public string? Question { get; set; }

        public string? Answer { get; set; }

        public bool Published { get; set; }
    }
}
