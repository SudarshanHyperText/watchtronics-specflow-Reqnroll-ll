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
    public class HomeSteps
    {
        private readonly HomePage HomePage;

        public HomeSteps()
        {
            HomePage = new HomePage(DriverManager.Driver); // pass WebDriver
        }

        [Given("user is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            HomePage.VerifyHomePageHeading();
            TestContext.WriteLine("User is on login page");
        }

        [When("user clicks on shop now button")]
        public void WhenUserClicksOnShopNowButton()
        {
            HomePage.ClickShopNow();
        }

        [Then("product page should be visible")]
        public void ThenProductPageShouldBeVisible()
        {
            HomePage.VerifyProductPageTitle();
            TestContext.WriteLine("User landed on product page");
        }

       

    }
}
