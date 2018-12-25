using System;
using Volo.Abp.Application.Dtos;

namespace Volo.HitCommerce.Customers.Dtos
{
    public class CustomerGroupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public bool IsActive { get; set; }
    }
}