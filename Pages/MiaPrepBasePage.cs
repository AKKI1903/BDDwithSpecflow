using System;
using OpenQA.Selenium;
using Miaplaza.Drivers;
using TechTalk.SpecFlow;
//This file contains the web elements and functions of the Mia Academy homepage
namespace Miaplaza.Pages
{
    public class MiaPrepBasePage
    {

        protected readonly IWebDriver Driver;

        public MiaPrepBasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToHomepage()
        {
            Driver.Navigate().GoToUrl("https://miaprep.com/online-school/"); // Replace with actual URL
        }

        public void ClickApplyNowButton()
        {
            Driver.FindElement(By.Id("apply-now-button")).Click(); // Replace with actual locator
        }

        public bool IsOnHomePage()
        {
            return Driver.Url.Contains("miaprep.com/online-school/");
        }
    }
}