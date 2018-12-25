using Volo.Abp.Application.Dtos;

namespace Volo.HitCommerce.Widgets.Dtos
{
    public class WidgetZoneDto : EntityDto<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}