using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.BaseEntities.Dtos;

namespace Volo.HitCommerce.BaseEntities
{
    public class BaseEntityAppService : ApplicationService, IBaseEntityAppService
    {
        private readonly IBaseEntityService _entityService;
        private readonly IBaseEntityTypeRepository _typeRepository;

        public BaseEntityAppService(
            IBaseEntityService entityService,
            IBaseEntityTypeRepository typeRepository
        )
        {
            _entityService = entityService;
            _typeRepository = typeRepository;
        }

        public async Task<GetBaseEntityOutputDto> GetEntityAsync(GetBaseEntityInputDto input)
        {
            var entity = await _entityService.GetAsync(input.EntityId);

            return new GetBaseEntityOutputDto
            {
                BaseEntity = ObjectMapper.Map<BaseEntity, BaseEntityDto>(entity),
                EntityTypeName = _typeRepository.Get(entity.BaseEntityTypeId).Name
            };
        }

        public async Task<BaseEntityDto> CreateAsync(BaseEntityCreateDto input)
        {
            var entity = await _entityService.AddAsync(
                input.Name,
                input.Slug,
                input.EntityId,
                input.BaseEntityTypeId
            );

            return ObjectMapper.Map<BaseEntity, BaseEntityDto>(entity);
        }

        public async Task<BaseEntityDto> UpdateAsync(BaseEntityUpdateDto input)
        {
            var entity = await _entityService.UpdateAsync(input.Name, input.Slug, input.EntityId);

            return ObjectMapper.Map<BaseEntity, BaseEntityDto>(entity);
        }

        public async Task DeleteAsync(Guid entityId)
        {
            await _entityService.RemoveAsync(entityId);
        }
    }
}