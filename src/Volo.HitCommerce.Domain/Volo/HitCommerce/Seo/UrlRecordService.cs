using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;
using Volo.HitCommerce.Helpers;

namespace Volo.HitCommerce.Seo
{
    public class UrlRecordService : DomainService, IUrlRecordService
    {
        private readonly IUrlRecordRepository _urlRecordRepository;
        private static Dictionary<string, string> _seoCharacterTable;

        public UrlRecordService(IUrlRecordRepository urlRecordRepository)
        {
            _urlRecordRepository = urlRecordRepository;
            _seoCharacterTable = CharHelper.InitializeSeoCharacter();
        }

        public async Task<UrlRecord> GetUrlRecordById(Guid urlRecordId)
        {
            return await _urlRecordRepository.GetAsync(urlRecordId);
        }

        public async Task<UrlRecord> GetByEntityIdAsync(Guid entityId)
        {
            return await _urlRecordRepository.GetByEntityId(entityId);
        }

        public async Task<UrlRecord> GetBySlugAsync(string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug));

            return await _urlRecordRepository.GetBySlug(slug);
        }

        public async Task<IList<UrlRecord>> GetUrlRecordsByIds(Guid[] urlRecordIds)
        {
            var query = await _urlRecordRepository.GetListAsync();

            return query.Where(p => urlRecordIds.Contains(p.Id)).ToList();
        }

        public async Task<string> GetActiveSlug(Guid entityId, string name)
        {
            var source = await _urlRecordRepository.GetListAsync();

            var query = from ur in source
                where ur.EntityId == entityId && ur.Name == name && ur.IsActive
                orderby ur.Id descending
                select ur.Slug;

            var slug = query.FirstOrDefault() ?? string.Empty;
            return slug;
        }

        public async Task<string> GetSeName<T>(T entity) where T : AggregateRoot<Guid>, ISlugSupported
        {
            Check.NotNull(entity, nameof(entity));
            return await GetSeName(entity.Id, entity.Name);
        }

        public async Task<string> GetSeName(Guid entityId, string name)
        {
            return await GetActiveSlug(entityId, name);
        }

        public string GetSeName(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyz1234567890 _-";
            name = name.Trim().ToLowerInvariant();

            var sb = new StringBuilder();

            foreach (var c in name.ToCharArray())
            {
                var c2 = c.ToString();

                if (convertNonWesternChars)
                    if (_seoCharacterTable?.ContainsKey(c2) ?? false)
                        c2 = _seoCharacterTable[c2];

                if (allowUnicodeCharsInUrls)
                {
                    if (char.IsLetterOrDigit(c) || validChars.Contains(c2)) sb.Append(c2);
                }
                else if (validChars.Contains(c2))
                {
                    sb.Append(c2);
                }
            }

            var name2 = sb.ToString();
            name2 = name2.Replace(" ", "-");
            while (name2.Contains("--")) name2 = name2.Replace("--", "-");
            while (name2.Contains("__")) name2 = name2.Replace("__", "_");
            return name2;
        }

        public async Task<UrlRecord> InsertAsync(Guid entityId, string name, string slug)
        {
            return await _urlRecordRepository.UpdateAsync(new UrlRecord(
                GuidGenerator.Create(),
                entityId,
                name,
                slug
                )
            {
                IsActive = true
            }, true);
        }

        public async Task<UrlRecord> UpdateAsync(Guid entityId, string name, string slug)
        {
            var urlRecord = await _urlRecordRepository.GetByEntityId(entityId);
            
            urlRecord.SetName(name);
            urlRecord.SetSlug(slug);

            return await _urlRecordRepository.UpdateAsync(urlRecord, true);
        }

        public async Task DeleteAsync(UrlRecord urlRecord)
        {
            Check.NotNull(urlRecord, nameof(urlRecord));
            await _urlRecordRepository.DeleteAsync(urlRecord);
        }

        public async Task DeleteAsync(IList<UrlRecord> urlRecords)
        {
            Check.NotNull(urlRecords, nameof(urlRecords));
            foreach (var urlRecord in urlRecords) await DeleteAsync(urlRecord);
        }

        public async Task SaveSlug<T>(T entity, string name, string slug) where T : AggregateRoot<Guid>, ISlugSupported
        {
            Check.NotNull(entity, nameof(entity));

            var entityId = entity.Id;

            var query = from ur in _urlRecordRepository.GetList()
                        where ur.EntityId == entityId &&
                              ur.Name == name
                        orderby ur.Id descending
                        select ur;
            
            var allUrlRecords = query.ToList();
            var activeUrlRecord = allUrlRecords.FirstOrDefault(x => x.IsActive);
            UrlRecord nonActiveRecord;

            if (activeUrlRecord == null && !string.IsNullOrWhiteSpace(slug))
            {
                nonActiveRecord = allUrlRecords
                    .FirstOrDefault(
                        x => x.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase) && !x.IsActive);
                
                if (nonActiveRecord != null)
                {
                    nonActiveRecord.IsActive = true;
                    await _urlRecordRepository.UpdateAsync(nonActiveRecord, true);
                }
                else
                {
                    var urlRecord = new UrlRecord(
                        GuidGenerator.Create(),
                        entityId,
                        name,
                        slug
                        )
                    {
                        IsActive = true
                    };

                    await _urlRecordRepository.InsertAsync(urlRecord, true);
                }
            }

            if (activeUrlRecord != null && string.IsNullOrWhiteSpace(slug))
            {
                activeUrlRecord.IsActive = false;
                await _urlRecordRepository.UpdateAsync(activeUrlRecord, true);
            }

            if (activeUrlRecord == null || string.IsNullOrWhiteSpace(slug))
                return;

            if (activeUrlRecord.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase))
                return;

            nonActiveRecord = allUrlRecords
                .FirstOrDefault(x => x.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase) && !x.IsActive);
            
            if (nonActiveRecord != null)
            {
                nonActiveRecord.IsActive = true;
                await _urlRecordRepository.UpdateAsync(nonActiveRecord, true);

                activeUrlRecord.IsActive = false;
                await _urlRecordRepository.UpdateAsync(activeUrlRecord, true);
            }
            else
            {
                var urlRecord = new UrlRecord(
                    GuidGenerator.Create(),
                    entityId,
                    name,
                    slug
                )
                {
                    IsActive = true
                };

                await _urlRecordRepository.InsertAsync(urlRecord, true);

                activeUrlRecord.IsActive = false;
                await _urlRecordRepository.UpdateAsync(activeUrlRecord, true);
            }
        }

        public async Task<string> ValidateSeName<T>(T entity, string seName, string name, bool ensureNotEmpty)
            where T : AggregateRoot<Guid>, ISlugSupported
        {
            Check.NotNull(entity, nameof(entity));
            return await ValidateSeName(entity.Id, seName, name, ensureNotEmpty);
        }

        public async Task<string> ValidateSeName(Guid entityId, string seName, string name, bool ensureNotEmpty)
        {
            if (string.IsNullOrWhiteSpace(seName) && !string.IsNullOrWhiteSpace(name)) seName = name;
            seName = GetSeName(seName, true, true);

            if (string.IsNullOrWhiteSpace(seName))
            {
                if (ensureNotEmpty)
                    seName = entityId.ToString();
                else
                    return seName;
            }

            var i = 2;
            var tempSeName = seName;

            while (true)
            {
                var urlRecord = await GetBySlugAsync(tempSeName);

                var reserved = urlRecord != null && !(urlRecord.EntityId == entityId &&
                                                      urlRecord.Name.Equals(name,
                                                          StringComparison.InvariantCultureIgnoreCase));

                if (!reserved) break;

                tempSeName = $"{seName}-{i}";
                i++;
            }

            seName = tempSeName;
            return seName;
        }
    }
}