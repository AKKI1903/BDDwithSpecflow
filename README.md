
# MiaAcademy Automation Project

## Overview

The Miaplaza Automation Project is a test automation framework built using SpecFlow and Selenium. It aims to automate the testing of the Miaplaza application, ensuring that all functionalities work as expected and providing a reliable regression testing suite.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
- [Visual Studio Code](https://code.visualstudio.com/) or any other IDE that supports C#
- [Selenium WebDriver](https://www.selenium.dev/documentation/en/webdriver/) installed
- [SpecFlow](https://specflow.org/) installed

## Installation

1. Clone the repository:
```bash
   git clone https://github.com/AKKI1903/MiaplazaAutomation.git
   cd MiaplazaAutomation
   ```   

2. Install packages:
```bash
   dotnet add package SpecFlow
   dotnet add package SpecFlow.NUnit
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.Support

   ```  

3. Restore the project dependencies:
```bash
   dotnet restore
   ```
4. Install Extensions
```bash
   C# for Visual Studio Code
   Cucumber
   SpecFlow Step Definition Generator
   ```

## Running Tests

To run the tests, use the following command:

```bash
   dotnet test .\Miaplaza.csproj
```

This will execute all the tests defined in the project.

## Project Structure

- **Pages**: Contains page object classes that encapsulate the functionality of each page in the Miaplaza application.
- **Steps**: Contains step definition files that map Gherkin steps to C# methods.
- **Features**: Contains Gherkin feature files that describe the behavior of the application.

## Writing Tests

1. **Create a Feature File**: Define the scenarios using Gherkin syntax in a `.feature` file.

2. **Implement Step Definitions**: Create corresponding step definitions in the Steps folder.

3. **Use Page Objects**: Interact with the application using methods defined in the page object classes.

## Example

Here’s a simple example of a feature file:

```gherkin
Feature: Student Information

  Scenario: Verify Student Information Page
    Given I am on the Miaplaza Homepage
    When I click on the Apply Now button
    Then I should be on the Student Information Page
```

## Acknowledgments

- [SpecFlow](https://specflow.org/)
- [Selenium](https://www.selenium.dev/)
```
