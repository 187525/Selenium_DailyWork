using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/h1[@class='page-title]")]
        private IWebElement? ProductTitleLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = "qty-inc")]
        private IWebElement? IncQty { get; set; }
        [FindsBy(How = How.Id, Using = "product-addtocart-button")]
        private IWebElement? AddToCart { get; set; }

        public string? GetProductTitleLabel()
        {
            return ProductTitleLabel?.Text;

        }
        public void ClickIncQty()
        {
            IncQty.Click();

        }
        public void ClickAddToCartBtn()
        {
            AddToCart.Click();

        }
    }
}

