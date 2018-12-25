using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.Customers.Dtos;

namespace Volo.HitCommerce.Customers
{
    public interface ICustomerAddressAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerAddressDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<CustomerAddressDto> CreateAsync(CustomerAddressCreateDto input);

        Task<CustomerAddressDto> UpdateAsync(Guid id, CustomerAddressUpdateDto input);

        Task SetAsDefault(Guid id);

        Task DeleteAsync(Guid id);
    }
}