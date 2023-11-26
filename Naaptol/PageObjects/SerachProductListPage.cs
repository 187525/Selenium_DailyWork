using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class SerachProductListPage
    {
        IWebDriver driver;

        public SerachProductListPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "productItem5")]
        public IWebElement fifthElement { get; set; }

        public SearchProduct ClickFifthElement()
        {
            fifthElement.Click();
            return new SearchProduct(driver);
        }
    }
}
