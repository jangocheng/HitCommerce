using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Volo.HitCommerce.MongoDB;

namespace Volo.HitCommerce.BaseEntities
{
    public class MongoBaseEntityRepository : MongoDbRepository<IHitCommerceMongoDbContext, BaseEntity, Guid>, IBaseEntityRepository
    {
        public MongoBaseEntityRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<BaseEntity>> GetAllByEntityType(Guid entityTypeId)
        {
            return await GetMongoQueryable().Where(x => x.BaseEntityTypeId == entityTypeId).ToListAsync();
        }

        public async Task<BaseEntity> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<BaseEntity> GetBySlug(string slug)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task<BaseEntity> GetByEntityId(Guid entityId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.EntityId == entityId);
        }
    }
}