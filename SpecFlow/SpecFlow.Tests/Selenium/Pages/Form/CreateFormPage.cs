using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Tests.Selenium.Helpers;
using SpecFlow.Tests.Selenium.Pages.About;
using SpecFlow.Tests.Selenium.Pages.Contacts;
using SpecFlow.Tests.Selenium.Pages.Home;
using SpecFlow.Tests.Selenium.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Pages.Form
{
    internal class CreateFormPage : APage, IHeader
    {
        protected HeaderPage Header { get; set; }

        public CreateFormPage(IWebDriver driver) : base(driver)
        {
            Header = new HeaderPage(Driver);
        }

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

        protected By NameInputBy = By.Id("Name");
        protected IWebElement NameInput => Driver.FindElement(NameInputBy);

        public CreateFormPage EnterName(string text)
        {
            Wait.Until(NameInputBy.IsDisplayed());

            NameInput.SendKeys(text);

            return this;
        }

        protected By DescriptionInputBy = By.Id("Description");
        protected IWebElement DescriptionInput => Driver.FindElement(DescriptionInputBy);

        public CreateFormPage EnterDescription(string text)
        {
            Wait.Until(DescriptionInputBy.IsDisplayed());

            DescriptionInput.SendKeys(text);

            return this;
        }

        protected By EnumSelectionBy = By.Id("EnumSelection");
        protected IWebElement EnumSelection => Driver.FindElement(EnumSelectionBy);
        protected SelectElement EnumSelect => new SelectElement(EnumSelection);

        public CreateFormPage SelectEnumByName(string text)
        {
            Wait.Until(EnumSelectionBy.IsDisplayed());

            EnumSelect.SelectByText(text);

            return this;
        }

        public CreateFormPage GoToCreateForm()
        {
            throw new NotImplementedException();
        }

        protected By SubmitBtnBy = By.Id("submit-form");
        protected IWebElement SubmitBtn => Driver.FindElement(SubmitBtnBy);

        public CreateFormPage SubmitInvalidForm()
        {
            Wait.Until(SubmitBtnBy.IsClickable());

            SubmitBtn.Click();

            return this;
        }
    }
}
