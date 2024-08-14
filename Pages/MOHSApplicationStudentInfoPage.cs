using OpenQA.Selenium;
using Miaplaza.Drivers;

namespace Miaplaza.Pages
{
    public class MOHSApplicationStudentInfoPage
    {

        protected readonly IWebDriver Driver;

        public MOHSApplicationStudentInfoPage(IWebDriver driver)
        {
            Driver = driver;
        }
        IWebElement StudentInfoPageVisible => Driver.FindElement(By.XPath("//*[@id='Section3-li']/h2/div/b"));
        public bool IsStudentInfoPageVisible()
        {
            return DriverHelper.WaitUntil(driver =>
                StudentInfoPageVisible.Displayed);
        }
    }
}