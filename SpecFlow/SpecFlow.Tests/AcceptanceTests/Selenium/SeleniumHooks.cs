using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.Tests.Selenium.Helpers;
using static SpecFlow.Tests.Selenium.Helpers.Enumerations;

namespace SpecFlow.Tests.AcceptanceTests
{
    internal class SeleniumHooks
    {
        protected IWebDriver Driver { get; private set; }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }

        protected void InitializeDriver(DriverType driverType)
        {
            Driver = WebDriverBuilder.CreateAndInitialize(driverType);
        }
    }
}
