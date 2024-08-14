using TechTalk.SpecFlow;
using Miaplaza.Drivers;

namespace Miaplaza.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            DriverHelper.InitializeDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            DriverHelper.QuitDriver();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = DriverHelper.GetDriver();
            driver.Manage().Window.Maximize();
            _scenarioContext["WebDriver"] = driver;
        }
    }
}
