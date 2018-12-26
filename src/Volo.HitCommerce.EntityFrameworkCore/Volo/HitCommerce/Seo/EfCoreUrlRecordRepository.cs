using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.HitCommerce.EntityFrameworkCore;

namespace Volo.HitCommerce.Seo
{
    public class EfCoreUrlRecordRepository : EfCoreRepository<IHitCommerceDbContext, UrlRecord, Guid>, IUrlRecordRepository
    {
        public EfCoreUrlRecordRepository(IDbContextProvider<IHitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<UrlRecord> GetByEntityId(Guid entityId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.EntityId == entityId);
        }

        public async Task<UrlRecord> GetBySlug(string slug)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Slug == slug);
        }
    }
}