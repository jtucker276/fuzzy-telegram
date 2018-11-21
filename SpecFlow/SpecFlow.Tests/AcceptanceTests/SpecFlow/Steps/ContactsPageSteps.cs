using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.Tests.Selenium.Helpers;
using SpecFlow.Tests.Selenium.Pages.Home;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Tests.AcceptanceTests.SpecFlow.Steps
{
    [Binding]
    internal class ContactsPageSteps : SpecFlowHooks
    {
        [Given(@"I have navigated to the home page")]
        public void GivenIHaveNavigatedToTheHomePage()
        {
            Navigation = new HomePage(Driver);
        }

        [When(@"I select Contacts")]
        public void WhenISelectContacts()
        {
            Navigation = Navigation.GoToContacts();
        }

        [Then(@"contact information should be displayed on the page")]
        public void ThenContactInformationShouldBeDisplayedOnThePage()
        {
            var expected = "One Microsoft Way\r\nRedmond, WA 98052-6399\r\nP: 425.555.0100";
            var actual = Navigation.GetContactInfo();

            Assert.AreEqual(expected, actual);
        }

        [Then(@"this step should fail")]
        public void ThenThisStepShouldFail()
        {
            Assert.Fail("This step intentionally failed.");
        }

        [Then(@"this step should skip")]
        public void ThenThisStepShouldSkip()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
