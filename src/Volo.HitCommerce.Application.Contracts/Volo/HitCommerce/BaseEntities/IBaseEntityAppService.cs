using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.BaseEntities.Dtos;

namespace Volo.HitCommerce.BaseEntities
{
    public interface IBaseEntityAppService : IApplicationService
    {
        Task<GetBaseEntityOutputDto> GetEntityAsync(GetBaseEntityInputDto input);
        
        Task<BaseEntityDto> CreateAsync(BaseEntityCreateDto input);

        Task<BaseEntityDto> UpdateAsync(BaseEntityUpdateDto input);

        Task DeleteAsync(Guid entityId);
    }
}