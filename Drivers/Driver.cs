using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Miaplaza.Drivers
{
    public static class DriverHelper
    {
        private static IWebDriver _driver;

        public static void InitializeDriver()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
            }
        }

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                InitializeDriver();
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }

        public static T WaitUntil<T>(Func<IWebDriver, T> condition, int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(condition);
        }

        public static void WaitAndClick(By by, int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(timeoutSeconds));

            IWebElement element = wait.Until(driver =>
            {
                var elementToClick = driver.FindElement(by);
                return (elementToClick.Displayed && elementToClick.Enabled) ? elementToClick : null;
            });
            
            element.Click();
        }
    }
}