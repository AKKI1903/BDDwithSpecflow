using Miaplaza.Drivers;
using Miaplaza.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        /* private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

         public StepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = DriverHelper.GetDriver(scenarioContext);
        _homePage = new HomePage(_driver);
    } */
        private readonly ScenarioContext _scenarioContext;
        private readonly HomePage _homePage;
        private readonly IWebDriver _driver;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = DriverHelper.GetDriver(scenarioContext);
            _homePage = new HomePage(scenarioContext);
        }


        [Given(@"I am on the MiaAcademy Home page")]
        public void GivenIamontheMiaAcademyHomepage()
        {
            _homePage.NavigateToHomePage();
        }

        [When(@"I Click on the banner for OHS")]
        public void WhenIClickonthebannerforOHS()
        {
            _homePage.ClickOnMiaPrepLink();
        }

        [Then(@"I land on the MiaPrep Homepage")]
        public void ThenIlandontheMiaPrepHomepage()
        {
            string expectedUrl = "https://miaprep.com/online-school/"; 
            DriverHelper.WaitUntil(_scenarioContext, driver => driver.Url == expectedUrl);
            Assert.AreEqual(expectedUrl, _driver.Url, "The URL is not as expected.");


        }
    }
}