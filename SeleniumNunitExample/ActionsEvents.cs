using OpenQA.Selenium;
using SeleniumNUnitExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNunitExample
{
    [TestFixture]
    internal class ActionsEvents : CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homeLink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomeLink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]/td[1]"));


            Actions actions = new Actions(driver);
            Action mouseOverAction = () => actions
            .MoveToElement(homeLink)
            .Build().Perform();

            Console.WriteLine("Before:" + tdhomeLink.GetCssValue("background-color"));
            mouseOverAction.Invoke();
            Console.WriteLine("After:" + tdhomeLink.GetCssValue("background-color"));
            mouseOverAction.Invoke();
        }

        [Test]

        public void MultiplesActionsTest()
        {
            driver.Navigate().GoToUrl("http://in.linkedin.com/");
            DefaultWait<IWebDriver> fluentwait=new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout=TimeSpan.FromSeconds(5); 
            fluentwait.PollingInterval=TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";

            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));
            Actions actions = new Actions(driver);
            Action UpperCaseInput = () => actions
            .KeyDown(Keys.Shift)
            .SendKeys(emailInput, "hello")
            .KeyUp(Keys.Shift)
            .Build()
            .Perform();

            UpperCaseInput.Invoke();
            Console.WriteLine("text is:" + emailInput.GetAttribute("value"));
            Thread.Sleep(1000); 

        
        
        
        }


    }
}
