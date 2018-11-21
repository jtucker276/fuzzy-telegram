using OpenQA.Selenium;
using SpecFlow.Tests.Selenium.Helpers;
using SpecFlow.Tests.Selenium.Pages.Contacts;
using SpecFlow.Tests.Selenium.Pages.Form;
using SpecFlow.Tests.Selenium.Pages.Home;
using SpecFlow.Tests.Selenium.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Pages.About
{
    internal class AboutPage : APage, IHeader
    {
        public AboutPage(IWebDriver driver) : base(driver)
        {
            Header = new HeaderPage(this.Driver);
        }

        protected HeaderPage Header { get; set; }

        protected By AboutTextBy = By.Id("aboutText");
        protected IWebElement AboutText => Driver.FindElement(AboutTextBy);

        public string GetAboutText()
        {
            Wait.Until(AboutTextBy.IsDisplayed());

            return AboutText.Text;
        }

        public HomePage GoHome()
        {
            return Header.GoHome();
        }

        public ContactsPage GoToContacts()
        {
            return Header.GoToContacts();
        }

        public AboutPage GoToAbout()
        {
            return Header.GoToAbout();
        }

        public CreateFormPage GoToCreateForm()
        {
            return Header.GoToCreateForm();
        }
    }
}
