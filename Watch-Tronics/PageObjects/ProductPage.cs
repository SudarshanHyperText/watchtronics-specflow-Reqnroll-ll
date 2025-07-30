using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_Tronics.PageObjects
{
    internal class ProductPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }
        private IWebElement SearchInput => _wait.Until(d => d.FindElement(By.XPath("//form[@class='searchbox']//input")));
        private IReadOnlyCollection<IWebElement> productElements => _wait.Until(d => d.FindElements(By.XPath("//div[@class='data']//p[@style='color: grey;']//b")));

        public void EnterSearchTerm(string keyword)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(keyword);
            Thread.Sleep(1000);
        }

        public List<string> GetVisibleProductNames()
        {
            return productElements.Select(el => el.Text.Trim().ToLower()).ToList();
        }
    }
}
