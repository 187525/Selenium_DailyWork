using BunnyCart.PageObjects;
using RedDiff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class SearchTests:CoreCodes
    {

        [Test]
        [TestCase("Water")]
        public void SearchProductAndAddToCart(string searchtext)
        {
            BCHP bchp = new(driver);
            var searchResultPage = bchp?.TypeSearchInput(searchtext);
            Assert.That(searchtext.Contains(searchResultPage?.GetFirstProductLInk()));
            var productPage = searchResultPage?.ClickFirstProductLink();
            Assert.That(searchtext.Equals(productPage?.GetProductTitleLabel()));
            productPage?.ClickIncQty();
            productPage?.ClickAddToCartBtn();
            Thread.Sleep(1000);

        }
    }
}
