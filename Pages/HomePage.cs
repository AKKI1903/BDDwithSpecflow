using System;
using OpenQA.Selenium;
using Miaplaza.Drivers;
using TechTalk.SpecFlow;
//This file contains the web elements and functions of the Mia Academy homepage
namespace Miaplaza.Pages
{
    public class HomePage
    {
        /*  private readonly IWebDriver _driver;
         private readonly WebDriverWait _wait;


         public HomePage(IWebDriver driver)
         {
             _driver = driver;
             _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
         }
  */
        private readonly ScenarioContext _scenarioContext;

        public HomePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private IWebElement MiaPrepLink => DriverHelper.WaitUntil(_scenarioContext,
            driver => driver.FindElement(By.LinkText("Online High School")));

        //   private IWebElement MiaPrepLink => _wait.Until(driver => driver.FindElement(By.LinkText("Online High School")));

        //Launching the Mia Academywebsite
        public void NavigateToHomePage()
        {
            var driver = DriverHelper.GetDriver(_scenarioContext);
            driver.Navigate().GoToUrl("https://miacademy.co/#/");
        }

        //Clicking on the Online High school link from homepage
        public void ClickOnMiaPrepLink()
        {
            var element = DriverHelper.WaitUntil(_scenarioContext, driver =>
    {
        var el = driver.FindElement(By.LinkText("Online High School"));
        return el.Displayed && el.Enabled ? el : null;
    });
            element.Click();
        }
    }
}