using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Configuration;

namespace HKOWebMVC4.Tests
{
    public static class HKOWebMVCBrowserHost
    {
        public static SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl;

        static HKOWebMVCBrowserHost()
        {
            Instance.Run("HKOWebMVC4", 4223, config => config.WithRouteConfig(RouteConfig.RegisterRoutes));
            RootUrl = Instance.Application.Browser.Url;
        }
    }
}
