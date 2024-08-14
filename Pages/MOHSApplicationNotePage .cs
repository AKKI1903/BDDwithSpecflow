using System;
using OpenQA.Selenium;
using Miaplaza.Drivers;
using TechTalk.SpecFlow;

namespace Miaplaza.Pages
{
    public class MOHSApplicationNotePage 
    {

        protected readonly IWebDriver Driver;

        public MOHSApplicationNotePage (IWebDriver driver)
        {
            Driver = driver;
        }

        public void InformationPage()
        {
            By linkLocator = By.XPath("//a[@href='https://tally.so/r/wkZEer']//span[contains(text(), 'take this quiz')]");

            bool isLinkVisible = DriverHelper.WaitUntil(driver =>
            {
                try
                {
                    var element = driver.FindElement(linkLocator);
                    return element.Displayed && element.Enabled;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            }, timeoutSeconds: 10);

            if (!isLinkVisible)
            {
                throw new Exception("The 'take this quiz' link is not visible on the page.");
            }
        }
    }
}