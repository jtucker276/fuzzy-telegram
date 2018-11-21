using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using SpecFlow.Tests.Selenium.Helpers;
using System;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using static SpecFlow.Tests.Selenium.Helpers.Enumerations;

namespace SpecFlow.Tests.AcceptanceTests.SpecFlow
{
    [Binding]
    internal class SpecFlowHooks
    {
        private static ExtentReports _extent;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        protected dynamic Navigation { get; set; }
        protected static IWebDriver Driver { get; private set; }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var filePath = Path.Combine(
                Path.GetFullPath(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        @"..\..\")),
                $"SpecFlow_Report_{DateTime.Now.ToString("yyyy-mm-dd_HHmm")}.html");
            var htmlReporter = new ExtentHtmlReporter(filePath);

            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            _feature = _extent
                .CreateTest<Feature>(
                FeatureContext.Current.FeatureInfo.Title,
                FeatureContext.Current.FeatureInfo.Description);
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            Driver = WebDriverBuilder.CreateAndInitialize(DriverType.Edge);
            _scenario = _feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Driver?.Quit();
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            var addStep = _scenario.CreateNode(
                new GherkinKeyword(
                    ScenarioStepContext
                        .Current
                        .StepInfo
                        .StepDefinitionType
                        .ToString()),
                ScenarioStepContext.Current.StepInfo.Text);

            switch (ScenarioContext.Current.ScenarioExecutionStatus)
            {
                case ScenarioExecutionStatus.OK:
                    break;
                case ScenarioExecutionStatus.StepDefinitionPending:
                    addStep.Skip("Step definition pending.");
                    break;
                case ScenarioExecutionStatus.UndefinedStep:
                    addStep.Warning("Undefined step.");
                    break;
                case ScenarioExecutionStatus.BindingError:
                    addStep.Error("Error binding step.");
                    break;
                case ScenarioExecutionStatus.TestError:
                    var testError = ScenarioContext.Current.TestError;
                    var testErrorMessage = testError.Message;
                    var testErrorStackTrace = testError.StackTrace;
                    var builder = new StringBuilder();

                    builder.AppendLine("TEST ERROR");
                    builder.AppendLine("ERROR MESSAGE:  " + testErrorMessage ?? "NONE");
                    builder.AppendLine("STACK TRACE:/r/n" + testErrorStackTrace ?? "NONE");

                    addStep.Fail(builder.ToString());
                    break;
                default:
                    break;
            }
        }
    }
}
