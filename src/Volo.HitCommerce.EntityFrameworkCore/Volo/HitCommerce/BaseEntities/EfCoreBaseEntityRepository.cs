using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.HitCommerce.EntityFrameworkCore;

namespace Volo.HitCommerce.BaseEntities
{
    public class EfCoreBaseEntityRepository : EfCoreRepository<IHitCommerceDbContext, BaseEntity, Guid>, IBaseEntityRepository
    {
        public EfCoreBaseEntityRepository(IDbContextProvider<IHitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<BaseEntity>> GetAllByEntityType(Guid entityTypeId)
        {
            return await DbSet.Where(x => x.BaseEntityTypeId == entityTypeId).ToListAsync();
        }

        public async Task<BaseEntity> GetByName(string name)
        {
            return await DbSet.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<BaseEntity> GetBySlug(string slug)
        {
            return await DbSet.Where(x => x.Slug == slug).FirstOrDefaultAsync();
        }

        public async Task<BaseEntity> GetByEntityId(Guid entityId)
        {
            return await DbSet.Where(x => x.EntityId == entityId).FirstOrDefaultAsync();
        }
    }
}