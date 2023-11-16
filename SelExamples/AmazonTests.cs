using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelExamples
{
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver(); //browser will open automatically
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();

        }

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }

        public void TiltleTest()
        {
            Thread.Sleep(2000); 
            Console.WriteLine("title " + driver.Title);
            Console.WriteLine("Title length " + driver.Title.Length);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo test - Pass");

        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That("Amazon.com : mobiles".Equals(driver.Title)&&(driver.Url.Contains("mobiles")));
            Console.WriteLine("Search test - Pass");

        }
        public void SignInAccListTest()
        {
            IWebElement hellosign = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosign == null) 
            {
                throw new NoSuchElementException("Hello signin is not present");
            }
            IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if(accountandlists == null)
            {
                throw new NoSuchElementException("Hello,account and list is not present");
            }
            Assert.That(hellosign.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello, sign in present- pass");
            Assert.That(accountandlists.Text.Equals("Account & Lists"));
            Console.WriteLine("Account and lists is present- pass");
        }
        public void SearchAndFilterProductByBrandtest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
             driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i")).Click();
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected); 
            Console.WriteLine("Motorola is selected");

            driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/i")).Click();
              
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Apple is selected");
        }
        public void SortBySelectTest()
        {
            IWebElement sortBy = driver.FindElement(By.ClassName(""));
            SelectElement sortbySelect = (SelectElement)sortBy;
            sortbySelect.
        }
        public void Destruct()
        {
            driver.Close();

        }
    }
}
