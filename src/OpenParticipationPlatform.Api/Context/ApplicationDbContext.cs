using Microsoft.EntityFrameworkCore;
using OpenParticipationPlatform.Api.Dbo;

namespace OpenParticipationPlatform.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<CategoryDbo> Categories { get; set; }
        public virtual DbSet<MapObjectDbo> MapObjects { get; set; }
        public virtual DbSet<FaqDbo> Faqs { get; set; }
        public virtual DbSet<UrlDbo> Urls { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
