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
    public class MongoBaseEntityTypeRepository : MongoDbRepository<IHitCommerceMongoDbContext, BaseEntityType, Guid>,
        IBaseEntityTypeRepository
    {
        public MongoBaseEntityTypeRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<BaseEntityType> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<BaseEntityType>> ListByAreaName(string areaName)
        {
            return await GetMongoQueryable().Where(x => x.AreaName == areaName)
                .ToListAsync();
        }
    }
}