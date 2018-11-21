using OpenQA.Selenium;
using SpecFlow.Tests.Selenium.Helpers;
using SpecFlow.Tests.Selenium.Pages.About;
using SpecFlow.Tests.Selenium.Pages.Contacts;
using SpecFlow.Tests.Selenium.Pages.Form;
using SpecFlow.Tests.Selenium.Pages.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Pages.Shared
{
    internal class HeaderPage : APage
    {
        public HeaderPage(IWebDriver driver) : base(driver)
        {
        }

        protected By HomeBtnBy = By.Id("homeBtn");
        protected IWebElement HomeBtn => Driver.FindElement(HomeBtnBy);

        public HomePage GoHome()
        {
            Wait.Until(HomeBtnBy.IsClickable());

            HomeBtn.Click();

            return new HomePage(Driver);
        }

        protected By ApplicationNameBy = By.Id("applicationNameBtn");
        protected IWebElement ApplicationNameBtn => Driver.FindElement(ApplicationNameBy);

        public HomePage GoHomeByName()
        {
            Wait.Until(ApplicationNameBy.IsClickable());

            ApplicationNameBtn.Click();

            return new HomePage(Driver);
        }

        protected By AboutBtnBy = By.Id("aboutBtn");
        protected IWebElement AboutBtn => Driver.FindElement(AboutBtnBy);

        public AboutPage GoToAbout()
        {
            Wait.Until(AboutBtnBy.IsClickable());

            AboutBtn.Click();

            return new AboutPage(Driver);
        }

        protected By ContactBtnBy = By.Id("contactBtn");
        protected IWebElement ContactBtn => Driver.FindElement(ContactBtnBy);

        public ContactsPage GoToContacts()
        {
            Wait.Until(ContactBtnBy.IsClickable());

            ContactBtn.Click();

            return new ContactsPage(Driver);
        }

        #region Form fill
        protected By CreateFormBtnBy = By.Id("createFormBtn");
        protected IWebElement CreateFormBtn => Driver.FindElement(CreateFormBtnBy);

        public CreateFormPage GoToCreateForm()
        {
            Wait.Until(CreateFormBtnBy.IsClickable());

            CreateFormBtn.Click();

            return new CreateFormPage(Driver);
        }
        #endregion
    }
}
