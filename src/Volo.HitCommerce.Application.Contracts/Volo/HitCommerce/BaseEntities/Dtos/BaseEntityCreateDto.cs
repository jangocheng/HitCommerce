using System;
using System.ComponentModel.DataAnnotations;

namespace Volo.HitCommerce.BaseEntities.Dtos
{
    public class BaseEntityCreateDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Slug { get; set; }

        public Guid EntityId { get; set; }

        public Guid BaseEntityTypeId { get; set; }
    }
}