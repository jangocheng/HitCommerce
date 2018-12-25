using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.HitCommerce.EntityFrameworkCore;

namespace Volo.HitCommerce.BaseEntities
{
    public class EfCoreBaseEntityTypeRepository : EfCoreRepository<IHitCommerceDbContext, BaseEntityType, Guid>,
        IBaseEntityTypeRepository
    {
        public EfCoreBaseEntityTypeRepository(IDbContextProvider<IHitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<BaseEntityType> GetByName(string name)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(name), x => x.AreaName == name)
                .FirstOrDefaultAsync();
        }

        public async Task<List<BaseEntityType>> ListByAreaName(string areaName)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(areaName), x => x.AreaName == areaName)
                .ToListAsync();
        }
    }
}