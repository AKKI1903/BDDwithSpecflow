@KeepBrowserOpen
Feature: Complete the MOHS Application
  As a user applying for the MOHS program
  I want to complete and submit the application form
  So that I can proceed with my application

Background:
  Given I am on the MiaPrep Homepage

Scenario: Navigate through the initial application process
  When I click on the Apply Now button
  Then the application form should be displayed
  When I click on Next on the initial form
  Then I should be on the Parent Information Page
  When I complete the parent information and click Next
  Then I should be on the Student Information Page