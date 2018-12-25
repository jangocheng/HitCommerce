using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.HitCommerce.EntityFrameworkCore
{
    public class HitCommerceModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public HitCommerceModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = HitCommerceConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommerceConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}