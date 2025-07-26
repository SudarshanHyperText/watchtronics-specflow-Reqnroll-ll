using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Watch_Tronics.Utilities; // DriverManager namespace
using Watch_Tronics.Utils;

namespace Watch_Tronics.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (ConfigReader.GetBrowser().ToLower() == "chrome")
            {
                DriverManager.Driver = new ChromeDriver();
            }

            DriverManager.Driver.Manage().Window.Maximize();
            DriverManager.Driver.Navigate().GoToUrl(ConfigReader.GetBaseUrl());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.Driver.Quit();
        }
    }
}
