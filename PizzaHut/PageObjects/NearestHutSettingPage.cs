using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHut.PageObjects
{
    internal class NearestHutSettingPage
    {
        IWebDriver? driver;
        public NearestHutSettingPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.Name, Using = "//span[text()='Kazhakkoottam, HV8G+C2C, Kazhakuttam, Thiruvananthapuram, Kerala 695582']")]
        [CacheLookup]
        private IWebElement? DeliveringToLabelBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Start my order']")]
        [CacheLookup]
        private IWebElement? StartMyOrderBtn { get; set; }

        //Act

        public void ClickStartMyOrderbutton()
        {
            StartMyOrderBtn?.Click();
        }

    }
}
