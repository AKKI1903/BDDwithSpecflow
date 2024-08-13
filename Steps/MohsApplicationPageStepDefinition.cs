using System;
using TechTalk.SpecFlow;
using Miaplaza.Pages;
using Miaplaza.Drivers;

namespace Miaplaza.StepDefinitions
{
    [Binding]
    public class MohsApplicationPageStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly MiaPrepBasePage _basePage;

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
        }

        [Then(@"the application form should be displayed")]
        public void Thentheapplicationformshouldbedisplayed()
        {
            _scenarioContext.Pending();
        }

        [When(@"I click on Next on the initial form")]
        public void WhenIclickonontheinitialform()
        {
            _scenarioContext.Pending();
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
