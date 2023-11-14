using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelAssignment
{
    internal class NavigationTest
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

        public void GoogleSearchTest()
        {
            //IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            //searchInputBox.SendKeys("Yahoo.com"); //to type inside the text box
            //Thread.Sleep(2000);
            //IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b")); // Name("btnK"))              //Name("btnK"));
            //googleSearchButton.Click();
            //Assert.AreEqual("yahoo - Google Search", driver.Title);
            //Console.WriteLine("GoogleSearchTest - Pass");
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");

        }
        public void DiwaliSearchTest()
        {
            driver.Navigate().Back();

            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("What's new for diwali 2023?"); //to type inside the text box
            Thread.Sleep(2000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b")); // Name("btnK"))              //Name("btnK"));
            googleSearchButton.Click();
            Assert.AreEqual("What's new for diwali 2023?", driver.Title);
            Console.WriteLine("DiwaliSearchTest - Pass");
            driver.Navigate().Refresh();    

        }

        public void Destruct()
        {
            driver.Close();

        }
    }
}
