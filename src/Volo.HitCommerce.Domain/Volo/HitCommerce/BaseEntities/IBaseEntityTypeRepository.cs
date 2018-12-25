using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.HitCommerce.BaseEntities
{
    public interface IBaseEntityTypeRepository : IBasicRepository<BaseEntityType, Guid>
    {
        Task<BaseEntityType> GetByName(string name);
        
        Task<List<BaseEntityType>> ListByAreaName(string areaName);
    }
}