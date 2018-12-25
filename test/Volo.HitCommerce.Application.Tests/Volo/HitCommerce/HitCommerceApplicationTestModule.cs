using Volo.Abp.Modularity;

namespace Volo.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceApplicationModule),
        typeof(HitCommerceDomainTestModule)
        )]
    public class HitCommerceApplicationTestModule : AbpModule
    {

    }
}
