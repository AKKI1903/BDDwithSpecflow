using System;
using TechTalk.SpecFlow;
using Miaplaza.Pages;
using Miaplaza.Drivers;
using OpenQA.Selenium;

namespace Miaplaza.StepDefinitions
{
    [Binding]
    public class MohsApplicationPageStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly MiaPrepBasePage _basePage;
        private int _currentPageNumber = 0;

        public MohsApplicationPageStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _basePage = new MiaPrepBasePage(DriverHelper.GetDriver());
        }

        [Given(@"I am on the MiaPrep Homepage")]
        public void GivenIamontheMiaPrepHomepage()
        {
            if (!_scenarioContext.ContainsKey("OnMiaPrepHomepage") || !(bool)_scenarioContext["OnMiaPrepHomepage"])
            {
                // Check if the current URL is correct
                string currentUrl = DriverHelper.GetDriver().Url;
                if (currentUrl != "https://miaprep.com/online-school/")
                {
                    throw new InvalidOperationException("Not on the MiaPrep Homepage");
                }

                _scenarioContext["OnMiaPrepHomepage"] = true;
            }
        }

        [When(@"I click on the Apply Now button")]
        public void WhenIclickonthebutton()
        {
            _basePage.ClickApplyNowButton();
            _currentPageNumber = 1;
        }

        [Then(@"the application form should be displayed")]
        public void Thentheapplicationformshouldbedisplayed()
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

        [When(@"I click on Next on the initial form")]
        public void WhenIclickonontheinitialform()
        {
            _basePage.ProceedToNextPage(_currentPageNumber);
            _currentPageNumber++;
        }

        [Then(@"I should be on the Parent Information Page")]
        public void ThenIshouldbeontheParentInformationPage()
        {
            _scenarioContext.Pending();
        }

        [When(@"I complete the parent information and click Next")]
        public void WhenIcompletetheparentinformationandclick()
        {
            _scenarioContext.Pending();
        }

        [Then(@"I should be on the Student Information Page")]
        public void ThenIshouldbeontheStudentInformationPage()
        {
            _scenarioContext.Pending();
        }
    }
}
