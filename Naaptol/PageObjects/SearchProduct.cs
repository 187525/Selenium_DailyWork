﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class SearchProduct
    {
        IWebDriver driver;

        public SearchProduct(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[text()='Rose Gold-3.00']")]
        public IWebElement Size { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='cart-panel-button-0']")]
        public IWebElement BuyNowButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@class='fancybox-item fancybox-close']")]
        public IWebElement Close { get; set; }

        public void SizeSelect()
        {
            Size.Click();
        }
        public void ClickBuyNow()
        {
            BuyNowButton.Click();
        }
        public string GetCurrentUrl()
        {
            return driver.Url;
        }
    }
}
