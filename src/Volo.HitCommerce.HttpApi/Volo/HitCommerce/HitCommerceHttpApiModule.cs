using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Volo.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class HitCommerceHttpApiModule : AbpModule
    {
        
    }
}
