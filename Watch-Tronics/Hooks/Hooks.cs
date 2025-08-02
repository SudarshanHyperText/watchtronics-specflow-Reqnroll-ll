using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Watch_Tronics.Utilities;
using Watch_Tronics.Utils;
using System;
using System.IO;
using System.Collections.Generic;

namespace Watch_Tronics.Hooks
{
    [Binding]
    public class Hooks
    {
        private static string reportPath = "TestReport.html";
        private static List<string> testResults = new List<string>();


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("=== CREATING TEST REPORT ===");

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");
            Directory.CreateDirectory(folderPath); // Ensure folder exists

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            reportPath = Path.Combine(folderPath, $"TestReport_{timestamp}.html");

            string htmlHeader = @"
<!DOCTYPE html>
<html>
<head>
    <title>Test Automation Report</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        h1 { color: #333; }
        table { border-collapse: collapse; width: 100%; margin-top: 20px; }
        th, td { border: 1px solid #ddd; padding: 12px; text-align: left; }
        th { background-color: #f2f2f2; }
        .pass { color: green; font-weight: bold; }
        .fail { color: red; font-weight: bold; }
    </style>
</head>
<body>
    <h1>Test Automation Report</h1>
    <p>Report Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"</p>
    <table>
        <tr>
            <th>Test Scenario</th>
            <th>Status</th>
            <th>Execution Time</th>
        </tr>";

            File.WriteAllText(reportPath, htmlHeader);
        }


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine($"=== STARTING SCENARIO: {scenarioContext.ScenarioInfo.Title} ===");

            if (ConfigReader.GetBrowser().ToLower() == "chrome")
            {
                DriverManager.Driver = new ChromeDriver();
            }
            DriverManager.Driver.Manage().Window.Maximize();
            DriverManager.Driver.Navigate().GoToUrl(ConfigReader.GetBaseUrl());
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            string status = scenarioContext.TestError == null ? "PASSED" : "FAILED";
            string statusClass = scenarioContext.TestError == null ? "pass" : "fail";
            string testName = scenarioContext.ScenarioInfo.Title;
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            Console.WriteLine($"=== SCENARIO RESULT: {testName} - {status} ===");

            if (scenarioContext.TestError != null)
            {
                Console.WriteLine($"ERROR: {scenarioContext.TestError.Message}");
            }

            // Add to HTML report
            string tableRow = $@"
        <tr>
            <td>{testName}</td>
            <td class=""{statusClass}"">{status}</td>
            <td>{timestamp}</td>
        </tr>";

            testResults.Add(tableRow);

            DriverManager.Driver.Quit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("=== FINALIZING TEST REPORT ===");

            // Complete HTML
            string htmlFooter = @"
    </table>
</body>
</html>";

            // Append all results
            foreach (string result in testResults)
            {
                File.AppendAllText(reportPath, result);
            }
            File.AppendAllText(reportPath, htmlFooter);

            string fullPath = Path.GetFullPath(reportPath);
            Console.WriteLine($"=== REPORT SAVED AT: {fullPath} ===");
            Console.WriteLine("=== OPEN THIS FILE IN BROWSER TO VIEW REPORT ===");
        }
    }
}