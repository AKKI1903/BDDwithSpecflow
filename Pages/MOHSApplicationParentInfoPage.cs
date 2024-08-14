using System;
using OpenQA.Selenium;
using Miaplaza.Drivers;

namespace Miaplaza.Pages
{
    public class MOHSApplicationParentInfoPage
    {

        protected readonly IWebDriver Driver;

        public MOHSApplicationParentInfoPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@elname='First']"));
        IWebElement LastNameField => Driver.FindElement(By.XPath("//input[@elname='Last']"));
        IWebElement EmailField => Driver.FindElement(By.XPath("//input[@name='Email']"));
        IWebElement selectedFlag => Driver.FindElement(By.CssSelector("div.selected-flag"));
        IWebElement countryElement => Driver.FindElement(By.CssSelector("li.country[data-country-code='de']"));
        
        IWebElement PhoneField => Driver.FindElement(By.XPath("//input[@id='PhoneNumber']"));
        IWebElement SecondParentInfoDropDown => Driver.FindElement(By.XPath("//span[@class='select2-selection select2-selection--single select2FormCont' and @role='combobox' and @aria-labelledby='select2-Dropdown-arialabel-container']"));
        IWebElement SecondParentInfoOptionNo => Driver.FindElement(By.XPath("//li[contains(@class, 'select2-results__option') and text()='No']"));
        IWebElement PreferredStartDateField => Driver.FindElement(By.XPath("//input[@id='Date-date']"));
        IWebElement HeardBySearchEngine => Driver.FindElement(By.CssSelector("[for='Checkbox_1']"));
        IWebElement MiaWebsite => Driver.FindElement(By.CssSelector("[for='Checkbox_2']"));
        public bool IsOnParentInfoPage()
        {
            return DriverHelper.WaitUntil(driver =>
                FirstNameField.Displayed &&
                LastNameField.Displayed &&
                EmailField.Displayed);
        }

        public void EnterDetails(string firstName, string lastName, string email, string phone)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            EmailField.SendKeys(email);
            selectedFlag.Click();
            DriverHelper.WaitUntil(d => d.FindElement(By.CssSelector("ul.country-list")).Displayed);
            countryElement.Click();

            PhoneField.SendKeys(phone);

            SecondParentInfoDropDown.Click();
            DriverHelper.WaitUntil(d => SecondParentInfoOptionNo.Displayed);
            SecondParentInfoOptionNo.Click();

            HeardBySearchEngine.Click();
            MiaWebsite.Click();
            DateTime nexttwoWeeks = DateTime.Today.AddDays(15);
            string date = nexttwoWeeks.ToString("dd-MMM-yyyy");
            PreferredStartDateField.SendKeys(date);
        }
    }
}