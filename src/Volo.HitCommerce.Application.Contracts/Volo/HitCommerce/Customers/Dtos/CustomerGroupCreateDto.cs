using System.ComponentModel.DataAnnotations;

namespace Volo.HitCommerce.Customers.Dtos
{
    public class CustomerGroupCreateDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public bool IsActive { get; set; }
    }
}