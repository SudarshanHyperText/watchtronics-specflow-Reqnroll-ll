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

    public class PrductSteps
    {
        private readonly ProductPage ProductPage;
        public PrductSteps()
        {
            ProductPage = new ProductPage(DriverManager.Driver); // pass WebDriver
        }

        [When(@"user types ""(.*)"" in the search box")]
        public void WhenUserTypesInTheSearchBox(string keyword)
        {
            ProductPage.EnterSearchTerm(keyword);
        }

        [Then(@"all visible products should contain ""(.*)""")]
        public void ThenAllVisibleProductsShouldContain(string keyword)
        {
            var products = ProductPage.GetVisibleProductNames();

            foreach (var name in products)
            {
                if (!name.Contains(keyword.ToLower()))
                {
                    throw new Exception($"Product name '{name}' does not contain '{keyword}'");
                }
            }

            Console.WriteLine("All product names matched the search keyword.");
        }

    }
}
