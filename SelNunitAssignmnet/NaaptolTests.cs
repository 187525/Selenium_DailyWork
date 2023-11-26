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
            Assert.That(driver.Url.Contains("Eyewear"));
            Thread.Sleep(5000);

           


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
       
        
            public void addingProductToCartTest()
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "Element not found.";

                IWebElement path = driver.FindElement(By.LinkText("Black-3.00"));

                Actions actions = new Actions(driver);
                Action selectingSize = () => actions.MoveToElement(path).Click()
                .Build()
                .Perform();

                selectingSize.Invoke();

                IWebElement buttonPath = driver.FindElement(By.XPath("//*[@id=\"cart-panel-button-0\"]/span"));
                Action addingToCart = () => actions.MoveToElement(buttonPath).Click()
                .Build()
                .Perform();
                addingToCart.Invoke();
                Assert.That(driver.Url.Contains("reading-glasses-with-led-lights-lrg4"));
                Thread.Sleep(3000);
            }


            [Order(3)]

            [Test]
            public void viewShoppingCartTest()
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "Element not found.";

                // IWebElement shoppingCart =driver.FindElement(By.Id("shopCartHead"));
                //Assert.That(shoppingCart.Text == "My Shopping Cart: At present, you have (1) items.");

                IWebElement closeButton = driver.FindElement(By.XPath("/html/body/div[5]/div/a"));
                Actions actions = new Actions(driver);
                Action addingToCart = () => actions.MoveToElement(closeButton).Click()
                .Build().Perform();
                addingToCart.Invoke();
                Thread.Sleep(2000);
            
            }



        }
}
