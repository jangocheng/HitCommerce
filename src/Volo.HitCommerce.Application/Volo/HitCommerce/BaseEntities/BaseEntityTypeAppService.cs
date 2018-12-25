using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.BaseEntities.Dtos;

namespace Volo.HitCommerce.BaseEntities
{
    public class BaseEntityTypeAppService : ApplicationService, IBaseEntityTypeAppService
    {
        private readonly IBaseEntityTypeRepository _typeRepository;

        public BaseEntityTypeAppService(IBaseEntityTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<ListResultDto<BaseEntityTypeDto>> GetMenuables()
        {
            var query = await _typeRepository.GetListAsync();

            var entityTypes = query.Where(x => x.IsMenuable).ToList();
            
            return new ListResultDto<BaseEntityTypeDto>(
                ObjectMapper.Map<List<BaseEntityType>, List<BaseEntityTypeDto>>(entityTypes)
                );
        }

        public async Task<BaseEntityTypeDto> GetAsync(Guid id)
        {
            var entityType = await _typeRepository.GetAsync(id);

            return ObjectMapper.Map<BaseEntityType, BaseEntityTypeDto>(entityType);
        }

        public async Task<BaseEntityTypeDto> CreateAsync(BaseEntityTypeCreateDto input)
        {
            var newEntityType = await _typeRepository.InsertAsync(
                new BaseEntityType(GuidGenerator.Create(), input.Name)
                );

            newEntityType.IsMenuable = input.IsMenuable;
            
            if (!string.IsNullOrWhiteSpace(input.AreaName))
            {
                newEntityType.SetRouter(input.RoutingController, input.RoutingAction, input.AreaName);
            }

            return ObjectMapper.Map<BaseEntityType, BaseEntityTypeDto>(newEntityType);
        }

        public async Task<BaseEntityTypeDto> UpdateAsync(Guid id, BaseEntityTypeUpdateDto input)
        {
            var entityType = await _typeRepository.GetAsync(id);
            
            entityType.SetName(input.Name);
            entityType.IsMenuable = input.IsMenuable;
            
            if (!string.IsNullOrWhiteSpace(input.AreaName))
            {
                entityType.SetRouter(input.RoutingController, input.RoutingAction, input.AreaName);
            }

            return ObjectMapper.Map<BaseEntityType, BaseEntityTypeDto>(entityType);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _typeRepository.DeleteAsync(id);
        }
    }
}