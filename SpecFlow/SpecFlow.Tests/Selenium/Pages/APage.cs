using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Pages
{
    internal abstract class APage
    {
        public APage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            WaitUntilLoaded();
        }

        protected IWebDriver Driver { get; set; }
        protected virtual WebDriverWait Wait { get; set; }

        private void WaitUntilLoaded()
        {
            Wait.Until((driver) =>
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete");
            });
        }
    }
}
