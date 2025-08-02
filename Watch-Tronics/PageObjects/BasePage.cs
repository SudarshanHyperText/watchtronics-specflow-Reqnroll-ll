using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Watch_Tronics.PageObjects
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return _wait.Until(d => d.FindElement(locator));
        }

        protected void ClickElement(By locator)
        {
            WaitForElement(locator).Click();
        }

        protected string GetElementText(By locator)
        {
            return WaitForElement(locator).Text;
        }
    }
}
