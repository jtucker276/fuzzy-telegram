using NUnit.Framework;
using SpecFlow.Tests.AcceptanceTests.Selenium;
using SpecFlow.Tests.Selenium.Pages.Home;
using static SpecFlow.Tests.Selenium.Helpers.Enumerations;

namespace SpecFlow.Tests.AcceptanceTests
{
    [TestFixture]
    internal class SeleniumTests : SeleniumHooks
    {
        [Test, MultiBrowserTest]
        public void AboutMenuGoesToAboutPage(DriverType driverType)
        {
            // Arrange
            InitializeDriver(driverType);

            var expected = "Use this area to provide additional information.";

            // Act
            var navigation = new HomePage(Driver)
                .GoToAbout();

            var actual = navigation.GetAboutText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test, MultiBrowserTest]
        public void ExampleNavigateAround(DriverType driverType)
        {
            // Arrange
            InitializeDriver(driverType);

            var expected = "ASP.NET is a free web framework for" +
                " building great Web sites and Web applications" +
                " using HTML, CSS and JavaScript.";

            // Act
            var navigation = new HomePage(Driver)
                .GoToAbout()
                .GoToContacts()
                .GoHome();

            var actual = navigation.GetInfoText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #region Form fill

        [TestCase(
            DriverType.Chrome,
            "John Smith",
            "This is my description",
            "SecondSelection")]
        public void FillOutFormTest(
            DriverType driverType,
            string name,
            string description,
            string enumSelection)
        {
            InitializeDriver(driverType);

            var navigation = new HomePage(Driver)
                .GoToCreateForm()
                .EnterName(name)
                .EnterDescription(description)
                .SelectEnumByName(enumSelection)
                .SubmitInvalidForm();


        }
        #endregion
    }
}
