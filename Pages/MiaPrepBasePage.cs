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
                var driver = DriverHelper.GetDriver();
                var applyNowLink = DriverHelper.WaitUntil(d => d.FindElement(By.LinkText("Apply Now")));
                applyNowLink.Click();

                DriverHelper.WaitUntil(driver => driver.Url.Contains("zohopublic.com"));

                Console.WriteLine("Successfully clicked on the Apply Now button");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking on Apply Now button: {ex.Message}");
                throw;
            }
        }
        
        public void ProceedToNextPage(int currentPageNum)
        {
            DriverHelper.WaitAndClick(By.CssSelector($"[page_no='{currentPageNum}'] button[elname='next']"));
        }
    }
}