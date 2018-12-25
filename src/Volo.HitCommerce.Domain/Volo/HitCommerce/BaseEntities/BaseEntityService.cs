using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Volo.HitCommerce.BaseEntities
{
    public class BaseEntityService : DomainService, IBaseEntityService
    {
        private readonly IBaseEntityRepository _baseEntityRepository;

        public BaseEntityService(IBaseEntityRepository baseEntityRepository)
        {
            _baseEntityRepository = baseEntityRepository;
        }

        public virtual async Task<BaseEntity> GetAsync(Guid entityId)
        {
            return await _baseEntityRepository.GetByEntityId(entityId);
        }

        public virtual async Task<BaseEntity> AddAsync(string name, string slug, Guid entityId, Guid baseEntityTypeId)
        {
            var entity = new BaseEntity(
                GuidGenerator.Create(),
                name,
                slug,
                entityId,
                baseEntityTypeId
            );

            return await _baseEntityRepository.InsertAsync(entity);
        }

        public virtual async Task<BaseEntity> UpdateAsync(string newName, string newSlug, Guid entityId)
        {
            var entity = await _baseEntityRepository.GetByEntityId(entityId);

            entity.SetName(newName);
            entity.SetSlug(newSlug);

            return await _baseEntityRepository.UpdateAsync(entity, true);
        }

        public virtual async Task RemoveAsync(Guid entityId)
        {
            var entity = await _baseEntityRepository.GetByEntityId(entityId);

            await _baseEntityRepository.DeleteAsync(entity);
        }
    }
}