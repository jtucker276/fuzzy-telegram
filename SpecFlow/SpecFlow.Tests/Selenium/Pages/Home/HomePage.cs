using OpenQA.Selenium;
using SpecFlow.Tests.Selenium.Helpers;
using SpecFlow.Tests.Selenium.Pages.About;
using SpecFlow.Tests.Selenium.Pages.Contacts;
using SpecFlow.Tests.Selenium.Pages.Form;
using SpecFlow.Tests.Selenium.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Pages.Home
{
    internal class HomePage : APage, IHeader
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Header = new HeaderPage(this.Driver);
        }

        protected HeaderPage Header { get; set; }

        public HomePage GoHome()
        {
            return Header.GoHome();
        }

        public AboutPage GoToAbout()
        {
            return Header.GoToAbout();
        }

        public ContactsPage GoToContacts()
        {
            return Header.GoToContacts();
        }

        protected By HomeInfoBy = By.Id("homePageInfo");
        protected IWebElement HomeInfo => Driver.FindElement(HomeInfoBy);

        public string GetInfoText()
        {
            Wait.Until(HomeInfoBy.IsDisplayed());

            return HomeInfo.Text;
        }

        public CreateFormPage GoToCreateForm()
        {
            return Header.GoToCreateForm();
        }
    }
}
