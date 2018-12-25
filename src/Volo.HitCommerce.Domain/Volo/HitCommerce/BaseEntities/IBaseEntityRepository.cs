using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.HitCommerce.BaseEntities
{
    public interface IBaseEntityRepository : IBasicRepository<BaseEntity, Guid>
    {
        Task<List<BaseEntity>> GetAllByEntityType(Guid entityTypeId);

        Task<BaseEntity> GetByName(string name);
        
        Task<BaseEntity> GetBySlug(string slug);

        Task<BaseEntity> GetByEntityId(Guid entityId);
    }
}