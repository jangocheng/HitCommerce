using System.ComponentModel.DataAnnotations;

namespace Volo.HitCommerce.BaseEntities.Dtos
{
    public class BaseEntityTypeCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string AreaName { get; set; }

        public string RoutingController { get; set; }

        public string RoutingAction { get; set; }
        
        public bool IsMenuable { get; set; }
    }
}