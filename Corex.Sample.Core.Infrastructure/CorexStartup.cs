using Corex.Presentation.Infrastructure;

namespace Corex.Sample.Core.Infrastructure
{
    public class CorexStartup : BaseStartup
    {
        public CorexStartup()
        {
            //Ioc initialize
            IoCManager.Install(this.Configuration);
        }
    }
}
