using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.HitCommerce.Addresses;
using Volo.HitCommerce.Customers;
using Volo.HitCommerce.Directions;
using Volo.HitCommerce.Medias;
using Volo.HitCommerce.Seo;
using Volo.HitCommerce.UserGroups;
using Volo.HitCommerce.Vendors;
using Volo.HitCommerce.Widgets;

namespace Volo.HitCommerce.EntityFrameworkCore
{
    [ConnectionStringName("HitCommerce")]
    public interface IHitCommerceDbContext : IEfCoreDbContext
    {
        DbSet<Address> Addresses { get; set; }
        
        DbSet<UrlRecord> UrlRecords { get; set; }
        
        DbSet<Customer> Users { get; set; }
        
        DbSet<CustomerAddress> UserAddresses { get; set; }
        
        DbSet<CustomerUserGroup> CustomerUserGroups { get; set; }
        
        DbSet<Country> Countries { get; set; }
        
        DbSet<StateOrProvince> StateOrProvinces { get; set; }
        
        DbSet<District> Districts { get; set; }
        
        DbSet<UserGroup> UserGroups { get; set; }
        
        DbSet<Media> Medias { get; set; }
        
        DbSet<Vendor> Vendors { get; set; }
        
        DbSet<Widget> Widgets { get; set; }
        
        DbSet<WidgetInstance> WidgetInstances { get; set; }
    }
}