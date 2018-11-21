using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using static SpecFlow.Tests.Selenium.Helpers.Enumerations;

namespace SpecFlow.Tests.Selenium.Helpers
{
    internal static class WebDriverBuilder
    {
        private static IWebDriver Create(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Edge:
                    return new EdgeDriver();
                case DriverType.IE:
                    return new InternetExplorerDriver();
                case DriverType.Firefox:
                    return new FirefoxDriver();
                case DriverType.Chrome:
                default:
                    return new ChromeDriver();
            }
        }

        public static IWebDriver CreateAndInitialize(DriverType driverType)
        {
            var driver = Create(driverType);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GUIHelper.GetBaseUri());

            return driver;
        }
    }
}
