using System.Collections.Generic;
using System.Globalization;

namespace Volo.HitCommerce.Helpers
{
    public static class CurrencyHelper
    {
        private static readonly List<string> ZeroDecimalCurrencies = new List<string> { "BIF", "DJF", "JPY", "KRW", "PYG", "VND", "XAF", "XPF", "CLP", "GNF", "KMF", "MGA", "RWF", "VUV", "XOF" };

        public static bool IsZeroDecimalCurrencies()
        {
            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);
            return ZeroDecimalCurrencies.Contains(regionInfo.ISOCurrencySymbol);
        }
    }
}
