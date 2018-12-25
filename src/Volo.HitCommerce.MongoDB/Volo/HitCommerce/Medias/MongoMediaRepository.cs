using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Volo.HitCommerce.MongoDB;

namespace Volo.HitCommerce.Medias
{
    public class MongoMediaRepository : MongoDbRepository<IHitCommerceMongoDbContext, Media, Guid>,
        IMediaRepository
    {
        public MongoMediaRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<Media> GetByFileName(string fileName)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.FileName == fileName);
        }
    }
}