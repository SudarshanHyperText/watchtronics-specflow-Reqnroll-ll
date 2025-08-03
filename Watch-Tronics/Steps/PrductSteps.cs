using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Linq;
using Watch_Tronics.PageObjects;
using Watch_Tronics.Utilities;

namespace Watch_Tronics.Steps
{
    [Binding]
    public class ProductSteps
    {
        private readonly ProductPage ProductPage;

        public ProductSteps()
        {
            ProductPage = new ProductPage(DriverManager.Driver);
        }

        [When(@"user types (.*) in the search box")]
        public void WhenUserTypesInTheSearchBox(string keyword)
        {
            ProductPage.EnterSearchTerm(keyword);
        }

        [Then(@"all visible products should contain (.*)")]
        public void ThenAllVisibleProductsShouldContain(string keyword)
        {
            var products = ProductPage.GetVisibleProductNames();

            foreach (var product in products)
            {
                Assert.IsTrue(product.ToLower().Contains(keyword.ToLower()),
                    $"Product '{product}' does not contain keyword '{keyword}'");
            }
        }
    }
}
