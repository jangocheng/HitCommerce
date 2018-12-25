using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Volo.HitCommerce.Addresses
{
    public class Address : AggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Phone { get; protected set; }

        [NotNull] 
        public virtual string AddressLine1 { get; protected set; }

        public virtual string AddressLine2 { get; protected set; }

        [NotNull] 
        public virtual string City { get; protected set; }

        [NotNull] 
        public virtual string ZipCode { get; protected set; }

        public virtual Guid CountryId { get; protected set; }

        public virtual Guid StateOrProvinceId { get; protected set; }

        public virtual Guid? DistrictId { get; protected set; }

        protected Address()
        {
        }

        public Address(
            Guid id,
            [NotNull] string phone,
            [NotNull] string addressLine1,
            [CanBeNull] string addressLine2,
            [NotNull] string city,
            [NotNull] string zipCode,
            Guid countryId,
            Guid stateOrProvinceId,
            Guid? districtId = null)
        {
            Id = id;
            Phone = Check.NotNullOrWhiteSpace(phone, nameof(phone));
            AddressLine1 = Check.NotNullOrWhiteSpace(addressLine1, nameof(addressLine1));
            AddressLine2 = addressLine2;
            City = Check.NotNullOrWhiteSpace(city, nameof(city));
            ZipCode = Check.NotNullOrWhiteSpace(zipCode, nameof(zipCode));
            DistrictId = districtId;
            StateOrProvinceId = stateOrProvinceId;
            CountryId = countryId;
        }
        
        public virtual Address UpdateAddress(
            [NotNull] string phone,
            [NotNull] string addressLine1,
            [CanBeNull] string addressLine2,
            [NotNull] string city,
            [NotNull] string zipCode,
            Guid countryId,
            Guid stateOrProvinceId,
            Guid? districtId)
        {
            Phone = Check.NotNullOrWhiteSpace(phone, nameof(phone));
            AddressLine1 = Check.NotNullOrWhiteSpace(addressLine1, nameof(addressLine1));
            AddressLine2 = addressLine2;
            City = Check.NotNullOrWhiteSpace(city, nameof(city));
            ZipCode = Check.NotNullOrWhiteSpace(zipCode, nameof(zipCode));
            DistrictId = districtId;
            StateOrProvinceId = stateOrProvinceId;
            CountryId = countryId;

            return this;
        }
        
    }
}