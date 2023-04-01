using System.ComponentModel.DataAnnotations;

namespace OpenParticipationPlatform.Api.OutputModel
{
    public class UrlViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Url { get; set; }
    }
}
