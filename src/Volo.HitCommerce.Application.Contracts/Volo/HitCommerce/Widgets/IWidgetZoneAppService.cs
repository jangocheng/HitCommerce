using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.Widgets.Dtos;

namespace Volo.HitCommerce.Widgets
{
    public interface IWidgetZoneAppService : IApplicationService
    {
        Task<ListResultDto<WidgetZoneDto>> GetListAsync();
    }
}