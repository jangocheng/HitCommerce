using System;
using System.ComponentModel.DataAnnotations;

namespace Volo.HitCommerce.Customers.Dtos
{
    public class CustomerAddressUpdateDto
    {
        public string Phone { get; set; }

        [Required] 
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        public Guid StateOrProvinceId { get; set; }

        public Guid? DistrictId { get; set; }

        public Guid CountryId { get; set; }

        public bool DisplayDistrict { get; set; }

        public bool DisplayZipCode { get; set; }

        public bool DisplayCity { get; set; }
    }
}