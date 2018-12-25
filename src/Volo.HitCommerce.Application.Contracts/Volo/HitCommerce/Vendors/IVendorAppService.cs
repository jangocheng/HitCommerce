using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.Vendors.Dtos;

namespace Volo.HitCommerce.Vendors
{
    public interface IVendorAppService : IApplicationService
    {
        Task<ListResultDto<VendorDto>> GetActiveVendorsAsync();
        
        Task<PagedResultDto<VendorDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<VendorDto> CreateAsync(VendorCreateDto input);

        Task<VendorDto> UpdateAsync(Guid id, VendorUpdateDto input);

        Task DeleteAsync(Guid id); 
    }
}