using OpenQA.Selenium;
using SpecFlow.Tests.Selenium.Helpers;
using SpecFlow.Tests.Selenium.Pages.About;
using SpecFlow.Tests.Selenium.Pages.Form;
using SpecFlow.Tests.Selenium.Pages.Home;
using SpecFlow.Tests.Selenium.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Pages.Contacts
{
    internal class ContactsPage : APage, IHeader
    {
        public ContactsPage(IWebDriver driver) : base(driver)
        {
            Header = new HeaderPage(this.Driver);
        }

        protected HeaderPage Header { get; set; }

        public HomePage GoHome()
        {
            return Header.GoHome();
        }

        protected By ContactInfoBy = By.Id("contactInfo");
        protected IWebElement ContactInfo => Driver.FindElement(ContactInfoBy);

        public string GetContactInfo()
        {
            Wait.Until(ContactInfoBy.IsDisplayed());

            return ContactInfo.Text.Trim();
        }

        public AboutPage GoToAbout()
        {
            return Header.GoToAbout();
        }

        public ContactsPage GoToContacts()
        {
            return Header.GoToContacts();
        }

        public CreateFormPage GoToCreateForm()
        {
            return Header.GoToCreateForm();
        }
    }
}
