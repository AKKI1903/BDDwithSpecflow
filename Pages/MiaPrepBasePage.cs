using System;
using OpenQA.Selenium;
using Miaplaza.Drivers;
using TechTalk.SpecFlow;

namespace Miaplaza.Pages
{
    public class MiaPrepBasePage
    {

        protected readonly IWebDriver Driver;

        public MiaPrepBasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickApplyNowButton()
        {
            try
            {
                // Get the WebDriver instance
                var driver = DriverHelper.GetDriver();

                // Wait for the element to be clickable and then click it
                var applyNowLink = DriverHelper.WaitUntil(d => d.FindElement(By.LinkText("Apply Now")));
                applyNowLink.Click();

                // Optional: Add a short wait or verification step
                DriverHelper.WaitUntil(d => d.Url.Contains("zohopublic.com"));

                Console.WriteLine("Successfully clicked on the Apply Now button");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking on Apply Now button: {ex.Message}");
                throw; // Re-throw the exception to fail the test
            }
        }

        protected IWebElement NextBtn(int pageNum) =>
            DriverHelper.GetDriver().FindElement(By.CssSelector($"[page_no='{pageNum}'] button[elname='next']"));
        public void ProceedToNextPage(int currentPageNum)
        {
            DriverHelper.WaitAndClick(By.CssSelector($"[page_no='{currentPageNum}'] button[elname='next']"));
        }
    }
}