using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;

namespace Volo.HitCommerce.Seo
{
    public interface IUrlRecordService : IDomainService
    {
        Task<UrlRecord> GetUrlRecordById(Guid urlRecordId);

        Task<UrlRecord> GetByEntityIdAsync(Guid entityId);

        Task<UrlRecord> GetBySlugAsync(string slug);

        Task<IList<UrlRecord>> GetUrlRecordsByIds(Guid[] urlRecordIds);

        Task<string> GetActiveSlug(Guid entityId, string name);

        Task<string> GetSeName<T>(T entity) where T : AggregateRoot<Guid>, ISlugSupported;

        Task<string> GetSeName(Guid entityId, string name);

        string GetSeName(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls);

        Task<UrlRecord> InsertAsync(Guid entityId, [NotNull] string name, [NotNull] string slug);

        Task<UrlRecord> UpdateAsync(Guid entityId, [NotNull] string name, [NotNull] string slug);

        Task DeleteAsync(UrlRecord urlRecord);

        Task DeleteAsync(IList<UrlRecord> urlRecords);

        Task SaveSlug<T>(T entity, string name, string slug) where T : AggregateRoot<Guid>, ISlugSupported;

        Task<string> ValidateSeName<T>(T entity, string seName, string name, bool ensureNotEmpty)
            where T : AggregateRoot<Guid>, ISlugSupported;

        Task<string> ValidateSeName(Guid entityId, string seName, string name, bool ensureNotEmpty);
    }
}