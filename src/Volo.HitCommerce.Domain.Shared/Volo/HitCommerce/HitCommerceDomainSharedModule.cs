using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.HitCommerce.Localization;

namespace Volo.HitCommerce
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class HitCommerceDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<HitCommerceResource>("en");
            });
        }
    }
}
