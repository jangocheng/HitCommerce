using System;
using Volo.Abp.Application.Dtos;

namespace Volo.HitCommerce.BaseEntities.Dtos
{
    public class BaseEntityTypeDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}