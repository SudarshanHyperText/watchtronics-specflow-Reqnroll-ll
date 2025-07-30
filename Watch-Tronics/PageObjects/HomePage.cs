using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Watch_Tronics.PageObjects
    {
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement Heading => _wait.Until(d => d.FindElement(By.XPath("//div[@class='center']//h1")));
        private IWebElement ShopNowButton => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Shop now']")));
        private IWebElement ProductTitle => _wait.Until(d => d.FindElement(By.XPath("//div[@class='section-center']//h2")));

        public void VerifyHomePageHeading()
        {
            string expected = "WatchTronics";
            string actual = Heading.Text;
            Assert.AreEqual(expected, actual, "Homepage heading did not match");
        }

        public void ClickShopNow()
        {
            ShopNowButton.Click();
        }

        public void VerifyProductPageTitle()
        {
            string expected = "Home/ products";
            string actual = ProductTitle.Text;
            Assert.AreEqual(expected, actual, "Product page title did not match");
        }
    }

}
