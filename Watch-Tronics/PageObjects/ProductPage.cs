using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _driver.FindElement(SearchInput).Clear();
            _driver.FindElement(SearchInput).SendKeys(keyword);
            Thread.Sleep(1000);
        }

        public List<string> GetVisibleProductNames()
        {
            var elements = _driver.FindElements(productElements);
            return elements.Select(el => el.Text.Trim().ToLower()).ToList();
        }
    }
}
