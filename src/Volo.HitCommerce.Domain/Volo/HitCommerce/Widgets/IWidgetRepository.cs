using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.HitCommerce.Widgets
{
    public interface IWidgetRepository : IBasicRepository<Widget, Guid>
    {
        Task<Widget> GetByName(string name);
    }
}