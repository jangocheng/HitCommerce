using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Volo.HitCommerce.MongoDB
{
    public class HitCommerceMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public HitCommerceMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = HitCommerceConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}