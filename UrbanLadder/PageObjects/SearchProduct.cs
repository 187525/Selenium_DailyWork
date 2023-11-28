using UrbanLadder.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanLadder.PageObjects
{
    internal class SearchProduct : CoreCodes
    {
        IWebDriver driver;

        public SearchProduct(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Close")]
        public IWebElement CloseBtn { get; set; }

        [FindsBy(How = How.Name, Using = "")]
        public IWebElement Size { get; set; }
        [FindsBy(How = How.Name, Using = "levelicon icofont-5inches")]
        public IWebElement Thickness { get; set; }
        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        public IWebElement AddToCartButton { get; set; }
        
        public void ClickCloseBtn()
        {
            CloseBtn.Click();
        }

        public void SizeSelect()
        {
            //CoreCodes.ScrollIntoView(driver, Size);
            Size.Click();

        }
        public void ThicknessSelect()
        {
            
            Thickness.Click();
        }
        public void ClickBuyNow()
        {

            //CoreCodes.ScrollIntoView(driver, AddToCartButton);
            AddToCartButton.Click();
        }
        public string GetCurrentUrl()
        {
            return driver.Url;
        }

    }
}


