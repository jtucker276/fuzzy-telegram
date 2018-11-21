using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Helpers
{
    internal static class Extensions
    {
        public static Func<IWebDriver, bool> IsClickable(this By by)
        {
            return (driver) =>
            {
                return by.IsDisplayed()(driver)
                    && by.IsEnabled()(driver);
            };
        }

        public static Func<IWebDriver, bool> IsDisplayed(this By by)
        {
            return (driver) =>
            {
                return driver.FindElement(by).Displayed;
            };
        }

        public static Func<IWebDriver, bool> IsEnabled(this By by)
        {
            return (driver) =>
            {
                return driver.FindElement(by).Enabled;
            };
        }
    }
}
