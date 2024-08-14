using System;
using TechTalk.SpecFlow;
using Miaplaza.Pages;
using Miaplaza.Drivers;
using NUnit.Framework;

namespace Miaplaza.StepDefinitions
{
    [Binding]
    public class MohsApplicationPageStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly MiaPrepBasePage _basePage;
        private readonly MOHSApplicationNotePage _notePage;
        private readonly MOHSApplicationParentInfoPage _ParentInfoPage;
        private readonly MOHSApplicationStudentInfoPage _StudentInfoPage;
        private int _currentPageNumber = 0;

        public MohsApplicationPageStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _basePage = new MiaPrepBasePage(DriverHelper.GetDriver());
            _notePage = new MOHSApplicationNotePage(DriverHelper.GetDriver());
            _ParentInfoPage = new MOHSApplicationParentInfoPage(DriverHelper.GetDriver());
            _StudentInfoPage = new MOHSApplicationStudentInfoPage(DriverHelper.GetDriver());
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

            _notePage.InformationPage();
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
            Assert.IsTrue(_ParentInfoPage.IsOnParentInfoPage());
            _ParentInfoPage.EnterDetails("Anthony", "Smith", "anthony.smith.1991.01@test.com", "1714445687");
        }

        [When(@"I complete the parent information and click Next")]
        public void WhenIcompletetheparentinformationandclick()
        {
            _basePage.ProceedToNextPage(_currentPageNumber);
            _currentPageNumber++;
        }

        [Then(@"I should be on the Student Information Page")]
        public void ThenIshouldbeontheStudentInformationPage()
        {
            bool isStudentPageVisible = _StudentInfoPage.IsStudentInfoPageVisible();
            Assert.IsTrue(isStudentPageVisible, "Student Information Page header is not visible.");

            // If we've reached this point, the test has passed
            Console.WriteLine("Test completed successfully: Student Information Page is visible.");

            // End the test by marking the scenario as complete 
            _scenarioContext["TestStatus"] = "Completed";

            
        }
    }
}
