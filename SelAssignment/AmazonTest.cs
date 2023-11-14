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
    internal class AmazonTest
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }


        public void TitleTest()
        {
            Thread.Sleep(2000); // To wait (10 seconds), only for viewing purpose .Should not include in the final code.
            Console.WriteLine("title " + driver.Title);
            Console.WriteLine("Title length " + driver.Title.Length);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        public void OrganizationType()
        {
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine("Organization Type-Pass");
        }

        public void Destruct()
        {
            driver.Close();

        }
    }
}
