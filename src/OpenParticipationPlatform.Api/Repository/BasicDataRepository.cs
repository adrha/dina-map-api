using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpenParticipationPlatform.Api.Context;
using OpenParticipationPlatform.Api.Dbo;

namespace OpenParticipationPlatform.Api.Repository
{
    public class BasicDataRepository
    {
        private readonly ApplicationDbContext context;

        public BasicDataRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<CategoryDbo>> GetAllCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<List<MapObjectDbo>> GetAllMapObjectsAsync(string[]? categoryShortNames)
        {
            var categoryIds = await context.Categories.Where(c => categoryShortNames == null || categoryShortNames.Contains(c.ShortName)).Select(c=> c.Id).ToListAsync();
            return await context.MapObjects.Where(c => categoryIds.Contains(c.CategoryId))
                .Include(o => o.Category)
                .Include(o => o.Urls)
                .ToListAsync();
        }

        public async Task <MapObjectDbo> CreateMapObjectAsync(MapObjectDbo mapObject)
        {
            mapObject.Id = Guid.NewGuid();
            await context.MapObjects.AddAsync(mapObject);
            await context.SaveChangesAsync();
            return await GetMapObjectByIdAsync(mapObject.Id.Value);
        }

        public async Task<MapObjectDbo> UpdateMapObjectAsync(Guid id, MapObjectDbo mapObject)
        {
            mapObject.Id = id;
            context.MapObjects.Update(mapObject);
            await context.SaveChangesAsync();
            return await GetMapObjectByIdAsync(mapObject.Id.Value);
        }

        public async Task <MapObjectDbo> GetMapObjectByIdAsync(Guid id)
        {
            return await context.MapObjects
                .Where(o => o.Id == id)
                .Include(o => o.Category)
                .SingleOrDefaultAsync();
        }

        public async Task<List<FaqDbo>> GetAllFaqsOfMapObjectAsync(Guid mapObjectId, bool filterOnlyPublished)
        {
            return await context.Faqs
                .Where(f => f.MapObjectId == mapObjectId && (!filterOnlyPublished && f.Published))
                .ToListAsync();
        }

        public async Task<List<UrlDbo>> GetAllUrlsOfMapObjectAsync(Guid mapObjectId)
        {
            return await context.Urls
                .Where(f => f.MapObjectId == mapObjectId)
                .ToListAsync();
        }
    }
}
