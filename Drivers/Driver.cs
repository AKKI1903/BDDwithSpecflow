using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;


namespace Miaplaza.Drivers
{
    public static class DriverHelper
    {
        public static IWebDriver GetDriver(ScenarioContext scenarioContext)
        {
            return scenarioContext["WebDriver"] as IWebDriver;
        }

        public static void QuitDriver(ScenarioContext scenarioContext)
        {
            var driver = GetDriver(scenarioContext);
            driver?.Quit();
        }

        public static T WaitUntil<T>(ScenarioContext scenarioContext, Func<IWebDriver, T> condition, int timeoutSeconds = 10)
        {
            var driver = GetDriver(scenarioContext);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(condition);
        }

    }
}
