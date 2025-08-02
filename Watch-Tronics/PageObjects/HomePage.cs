using OpenQA.Selenium;
using NUnit.Framework;

namespace Watch_Tronics.PageObjects
{
    public class HomePage : BasePage
    {
        private readonly By headingLocator = By.XPath("//div[@class='center']//h1");
        private readonly By shopNowBtnLocator = By.XPath("//button[text()='Shop now']");
        private readonly By productTitleLocator = By.XPath("//div[@class='section-center']//h2");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyHomePageHeading()
        {
            string expected = "WatchTronics";
            string actual = GetElementText(headingLocator);
            Assert.AreEqual(expected, actual, "Homepage heading did not match");
        }

        public void ClickShopNow()
        {
            ClickElement(shopNowBtnLocator);
        }

        public void VerifyProductPageTitle()
        {
            string expected = "Home/ products";
            string actual = GetElementText(productTitleLocator);
            Assert.AreEqual(expected, actual, "Product page title did not match");
        }
    }
}
