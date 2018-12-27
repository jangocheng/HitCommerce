using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Seo
{
    public interface IUrlRecordRepository : IBasicRepository<UrlRecord, Guid>
    {
        Task<UrlRecord> GetByEntityId(Guid entityId);
        
        Task<UrlRecord> GetBySlug(string slug);
    }
}