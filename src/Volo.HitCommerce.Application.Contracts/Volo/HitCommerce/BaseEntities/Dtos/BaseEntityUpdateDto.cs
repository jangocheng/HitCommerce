using System;
using System.ComponentModel.DataAnnotations;

namespace Volo.HitCommerce.BaseEntities.Dtos
{
    public class BaseEntityUpdateDto
    {
        public Guid EntityId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Slug { get; set; }
    }
}