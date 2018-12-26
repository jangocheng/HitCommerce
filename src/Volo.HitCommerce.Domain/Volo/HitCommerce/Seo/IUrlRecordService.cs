using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Volo.HitCommerce.Seo
{
    public interface IUrlRecordService : IDomainService
    {
        Task<UrlRecord> GetByIdAsync(Guid urlRecordId);

        Task<UrlRecord> GetByEntityIdAsync(Guid entityId);

        Task<UrlRecord> GetBySlugAsync([NotNull] string slug);

        Task<IList<UrlRecord>> GetUrlRecordsByIds(Guid[] urlRecordIds);

        Task<string> GetActiveSlug(Guid entityId,[NotNull] string name);

        Task<string> GetSeName(Guid entityId, [NotNull] string name);

        string GetSeName([NotNull] string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls);

        Task<UrlRecord> InsertAsync(Guid entityId, [NotNull] string name, [NotNull] string slug);

        Task<UrlRecord> UpdateAsync(Guid entityId, [NotNull] string name, [NotNull] string slug);

        Task DeleteAsync(UrlRecord urlRecord);

        Task DeleteAsync(IList<UrlRecord> urlRecords);

        Task SaveSlug(Guid entityId, [NotNull] string name, [NotNull] string slug);

        Task<string> ValidateSeName(Guid entityId, [NotNull] string name, bool ensureNotEmpty);
    }
}