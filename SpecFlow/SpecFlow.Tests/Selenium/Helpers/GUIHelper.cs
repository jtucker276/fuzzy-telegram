using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Helpers
{
    internal static class GUIHelper
    {
        public static Uri GetBaseUri()
        {
            var uriString = ConfigurationManager.AppSettings.Get("baseTestUri") ?? "";

            return new Uri(uriString);
        }
    }
}
