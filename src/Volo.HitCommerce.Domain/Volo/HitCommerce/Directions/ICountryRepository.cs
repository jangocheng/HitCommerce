using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.HitCommerce.Directions
{
    public interface ICountryRepository : IBasicRepository<Country, Guid>
    {
        Task<List<Country>> GetAllCountriesForBilling();

        Task<List<Country>> GetAllCountriesForShipping();

        Task<Country> GetCountryByCode(string isoCode);
    }
}