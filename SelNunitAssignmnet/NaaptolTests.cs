using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumNUnitExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace SelNunitAssignmnet
{
    internal class NaaptolTests : CoreCodes
    {
        [Test]
        [Order(0)]
        public void SearchProduct()
        {

           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "element not found";

            
            IWebElement SearchInput = fluentwait.Until(driv => driv.FindElement(By.XPath("//*[@id=\"header_search_text\"]")));
            SearchInput.SendKeys("Eyewear");
            SearchInput.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            Assert.That(driver.Url.Contains("Eyewear"));


        }
        [Test]
        [Order(1)]
        [TestCase(5)]
        public void SelectFifthElement(int pid)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "element not found";

            string path="//div[@id='productItem" + pid + "']";
            IWebElement FifthElement=fluentwait.Until(d => d.FindElement(By.XPath(path)));
            Actions actions = new Actions(driver);
            Action moveto = () => actions.MoveToElement(FifthElement)
            .Click().Build().Perform();
            moveto.Invoke();
            
            Thread.Sleep(5000);

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
        }

        [Test]
        [Order(2)]
       
        public void AddProductCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found";
            IWebElement selectsize = fluentwait.Until(d => d.FindElement(By.XPath("//a[text()='Black-2.50']")));


            selectsize.Click();
            IWebElement submitbutton = fluentwait.Until(d => d.FindElement(By.XPath("//*[@id=\"cart-panel-button-0\"]/span")));
            submitbutton.Click();
            IWebElement status = fluentwait.Until(d => d.FindElement(By.XPath("//*[text()='My Shopping Cart: ']")));
            Assert.That(status.Text.Contains("cart"));

        }
        



    }
}
