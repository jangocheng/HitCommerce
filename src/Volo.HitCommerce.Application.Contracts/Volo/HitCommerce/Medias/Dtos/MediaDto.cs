using System;
using Volo.Abp.Application.Dtos;

namespace Volo.HitCommerce.Medias.Dtos
{
    public class MediaDto : EntityDto<Guid>
    {
        public string MediaUrl { get; set; }
        
        public string ThumbnailUrl { get; set; }
    }
}