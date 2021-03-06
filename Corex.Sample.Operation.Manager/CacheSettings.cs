using Corex.Cache.Infrastructure;
using Corex.Operation.Inftrastructure;

namespace Corex.Sample.Operation.Manager
{
    public class CacheSettings : ICacheSettings
    {
        public CacheSettings()
        {
            CacheTime = 50000;
        }

        public ICacheManager CacheManager { get; set; }
        public string Prefix { get; set; }
        public int CacheTime { get; set; }
    }
}
