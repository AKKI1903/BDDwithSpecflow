using System;
using Miaplaza.Drivers;
using Miaplaza.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Miaplaza.StepDefinitions
{
    [Binding]
    public class HomepageStepDefinition
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

        public HomepageStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = DriverHelper.GetDriver();
            _homePage = new HomePage();
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
            if (_driver == null)
            {
                throw new InvalidOperationException("WebDriver is not initialized.");
            }

            DriverHelper.WaitUntil(driver => driver.Url == expectedUrl);
            Assert.AreEqual(expectedUrl, _driver.Url, "The URL is not as expected.");

            if (_scenarioContext == null)
            {
                throw new InvalidOperationException("ScenarioContext is not initialized.");
            }

            _scenarioContext["OnMiaPrepHomepage"] = true;
        }
    }
}