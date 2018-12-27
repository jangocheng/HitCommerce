using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Seo
{
    public class MongoUrlRecordRepository : MongoDbRepository<IHitCommerceMongoDbContext, UrlRecord, Guid>, IUrlRecordRepository
    {
        public MongoUrlRecordRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<UrlRecord> GetByEntityId(Guid entityId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.EntityId == entityId);
        }

        public async Task<UrlRecord> GetBySlug(string slug)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Slug == slug);
        }
    }
}