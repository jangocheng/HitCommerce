using System;
 using Volo.Abp.Application.Dtos;
 
 namespace Volo.HitCommerce.BaseEntities.Dtos
 {
     public class BaseEntityDto : EntityDto<Guid>
     {
         public string Name { get; set; }
         
         public string Slug { get; set; }
         
         public Guid EntityTypeId { get; set; }
     }
 }