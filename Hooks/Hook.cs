using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
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

        [BeforeScenario]
        public void BeforeScenario()
        {
/*             var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); */
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverHelper.QuitDriver(_scenarioContext);
        }
    }
}
