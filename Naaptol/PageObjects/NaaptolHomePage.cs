using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naaptol.PageObjects;

namespace Naaptol.PageObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver driver;
        public NaaptolHomePage(IWebDriver? driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "header_search_text")] //how to find create acc element
        public IWebElement?   searchElement { get; set; }

        public void TypeSearchBox(string product)
        {
            searchElement.SendKeys(product);
            searchElement.SendKeys(Keys.Enter);


        }

    }

}
