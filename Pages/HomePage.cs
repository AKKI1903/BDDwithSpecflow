using System;
using OpenQA.Selenium;
using Miaplaza.Drivers;
using TechTalk.SpecFlow;
//This file contains the web elements and functions of the Mia Academy homepage
namespace Miaplaza.Pages
{
    public class HomePage
    {
        //Launching the Mia Academywebsite
        public void NavigateToHomePage()
        {
            DriverHelper.GetDriver().Navigate().GoToUrl("https://miacademy.co/#/");
        }

        //Clicking on the Online High school link from homepage
        public void ClickOnMiaPrepLink()
        {
            var miaPrepLink = DriverHelper.WaitUntil(driver =>
                {
                    var element = driver.FindElement(By.LinkText("Online High School"));
                    return element.Displayed && element.Enabled ? element : null;
                });
            miaPrepLink.Click();
        }
    }
}
