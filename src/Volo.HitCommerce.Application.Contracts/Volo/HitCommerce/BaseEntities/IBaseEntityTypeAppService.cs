using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.BaseEntities.Dtos;

namespace Volo.HitCommerce.BaseEntities
{
    public interface IBaseEntityTypeAppService : IApplicationService
    {
        Task<ListResultDto<BaseEntityTypeDto>> GetMenuables();
        
        Task<BaseEntityTypeDto> GetAsync(Guid id);
        
        Task<BaseEntityTypeDto> CreateAsync(BaseEntityTypeCreateDto input);

        Task<BaseEntityTypeDto> UpdateAsync(Guid id, BaseEntityTypeUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}