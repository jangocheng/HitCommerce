using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.HitCommerce.Directions
{
    public interface IStateOrProvinceRepository : IBasicRepository<StateOrProvince, Guid>
    {
        Task<List<StateOrProvince>> GetAllByCountryId(Guid countryId);

        Task<StateOrProvince> GetByName(string name);
    }
}