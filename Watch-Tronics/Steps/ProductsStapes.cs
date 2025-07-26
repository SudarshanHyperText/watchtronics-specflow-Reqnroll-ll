using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Reqnroll;
using Watch_Tronics.PageObjects;
using Watch_Tronics.Utilities; // DriverManager namespace


namespace Watch_Tronics.Steps
{
    [Binding]
    public class ProductSteps
    {
        private readonly ProductPage ProductPage;

        public ProductSteps()
        {
            ProductPage = new ProductPage(DriverManager.Driver); // pass WebDriver
        }

        [Given("user is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            ProductPage.VerifyHomePageHeading();
            TestContext.WriteLine("User is on login page");
        }

        [When("user clicks on shop now button")]
        public void WhenUserClicksOnShopNowButton()
        {
            ProductPage.ClickShopNow();
        }

        [Then("product page should be visible")]
        public void ThenProductPageShouldBeVisible()
        {
            ProductPage.VerifyProductPageTitle();
            TestContext.WriteLine("User landed on product page");
        }


    }
}
