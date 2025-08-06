using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers; // Needed for ExpectedConditions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Watch_Tronics.PageObjects
{
    internal class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By SearchInput = By.XPath("//form[@class='searchbox']//input");
        private readonly By productElements = By.XPath("//div[@class='data']//p[@style='color: grey;']//b");

        public void EnterSearchTerm(string keyword)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(SearchInput)); // wait until input is visible

            _driver.FindElement(SearchInput).Clear();
            _driver.FindElement(SearchInput).SendKeys(keyword);
            Thread.Sleep(1000); // optional, depends on app response time
        }

        public List<string> GetVisibleProductNames()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(productElements));

            var elements = _driver.FindElements(productElements);
            return elements.Select(el => el.Text.Trim().ToLower()).ToList();
        }
    }
}
