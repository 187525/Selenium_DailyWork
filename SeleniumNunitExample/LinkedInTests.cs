using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumNUnitExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    internal class LinkedInTests:CoreCodes
    {
        [Test, Category("Regression Testing"), Author("Arya", "aryamol105@gmail.com")]
        [Description("Check for valid login")]
       
        public void Login1Test()
        {
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));

            //IWebElement emailInput = wait.Until(driv => driv.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(driv => driv.FindElement(By.Id("session_password")));
            
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout= TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval= TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "element not found";

            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_password")));
            
            
            emailInput.SendKeys("abcd@gmail.com");
            passwordInput.SendKeys("1234567");
           
        }
        //[Test, Author("Arya", "aryamol105@gmail.com"), Category("Smoke Testing")]
        //[Description("check for invalid login")]

        /*public void Login2TestwithInvalidCred()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "element not found";

            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_password")));


            emailInput.SendKeys("abcd@gmail.com");
            passwordInput.SendKeys("12345");
            Thread.Sleep(1000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            emailInput.SendKeys("ab@gmail.com");
            passwordInput.SendKeys("1234");
            Thread.Sleep(1000);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            
            
            emailInput.SendKeys("att@gmail.com");
            passwordInput.SendKeys("123");
            Thread.Sleep(1000);
            ClearForm(emailInput);
            ClearForm(passwordInput);
        }*/
        void ClearForm(IWebElement element)
        {
            element.Clear();

        }



       /* [Test]
        [Author("AAA", "aryamol@gmail.com")]
        [Description("check for invalid login"), Category("Simple Testing")]
        [TestCase("abcd@gmail.com","12345")]
        [TestCase("ab@gmail.com", "1234")]
        [TestCase("att@gmail.com", "123")]
        
     
      
        public void Login2TestwithInvalidCred(string email,string pwd)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "element not found";

            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(1000);
}*/
        [Test]
        [Author("AAA", "aryamol@gmail.com")]
        [Description("check for invalid login"), Category("Simple Testing")]
        [TestCaseSource(nameof(invalidLoginData))]


        public void Login2TestwithInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "element not found";

            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            TakeScreenshot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", 
                driver.FindElement(By.XPath("//button[@type='submit']")));
            TakeScreenshot();
            Thread.Sleep(5000);
            js.ExecuteScript("arguments[0].click();",
                driver.FindElement(By.XPath("//button[@type='submit']")));
            TakeScreenshot();



            ClearForm(emailInput);
          ClearForm(passwordInput);


           // Thread.Sleep(TimeSpan.FromSeconds(3));
        }
        static object[] invalidLoginData()

        {
            return new object[]
            {
                new object[] {"qwerty@aa.com","aa"},
                new object[] {"asdfg@xx.com","bbbb"}
            };
        }

        
    }
}
