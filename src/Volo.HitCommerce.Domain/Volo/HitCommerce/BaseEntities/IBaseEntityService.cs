using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Volo.HitCommerce.BaseEntities
{
    public interface IBaseEntityService : IDomainService
    {
        Task<BaseEntity> GetAsync(Guid entityId);

        Task<BaseEntity> AddAsync(string name, string slug, Guid entityId, Guid baseEntityTypeId);

        Task<BaseEntity> UpdateAsync(string newName, string newSlug, Guid entityId);

        Task RemoveAsync(Guid entityId);
    }
}