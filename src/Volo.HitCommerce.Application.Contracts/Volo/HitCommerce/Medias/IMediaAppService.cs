using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.HitCommerce.Medias.Dtos;

namespace Volo.HitCommerce.Medias
{
    public interface IMediaAppService : IApplicationService
    {
        Task<MediaDto> GetMediaUrl(GetMediaUrlInputDto input);
    }
}