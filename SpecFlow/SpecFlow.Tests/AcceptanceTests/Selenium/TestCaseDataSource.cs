using NUnit.Framework;
using System.Collections;
using static SpecFlow.Tests.Selenium.Helpers.Enumerations;

namespace SpecFlow.Tests.AcceptanceTests.Selenium
{
    internal class TestCaseDataSource
    {
        public static IEnumerable BrowserCases
        {
            get
            {
                yield return new TestCaseData(DriverType.Edge);
                yield return new TestCaseData(DriverType.Chrome);
            }
        }
    }

    internal class MultiBrowserTest : TestCaseSourceAttribute
    {
        public MultiBrowserTest()
            : base(typeof(TestCaseDataSource), nameof(TestCaseDataSource.BrowserCases))
        {

        }
    }
}
