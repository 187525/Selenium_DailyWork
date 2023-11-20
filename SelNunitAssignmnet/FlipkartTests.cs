using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumNUnitExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelNunitAssignmnet
{
    internal class FlipkartTest:CoreCodes
    {
        [Test]

        public void Login1Test()
        {
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //IWebElement emailInput = wait.Until(driv => driv.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(driv => driv.FindElement(By.Id("session_password")));

            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "element not found";

            driver.FindElement(By.XPath("/html/body/div[3]/div/span")).Click();
            IWebElement SearchInput = fluentwait.Until(driv => driv.FindElement(By.ClassName("Pke_EE")));
            SearchInput.SendKeys("laptops");
            SearchInput.SendKeys(Keys.Enter);

        }
    }
}
