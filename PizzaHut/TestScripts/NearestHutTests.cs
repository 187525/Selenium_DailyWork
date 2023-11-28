using OpenQA.Selenium;
using PizzaHut.PageObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHut.TestScripts 
{
    internal class NearestHutTests: CoreCodes
    {
        [Test]
        public void NearestHutTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();


            NearestHutSettingPage nhsp = new NearestHutSettingPage(driver);
            Log.Information("Checking the delivery location");
            //try
            //{
                IWebElement labelElement = driver.FindElement(By.XPath("//span[text()='Collecting from']"));

                // Assert that the label element is not null
                Assert.AreEqual(labelElement.Text, "Collecting from");
            //}

            //nhsp.ClickStartMyOrderbutton();
            //Log.Information("Start my order Button Clicked");
            //Thread.Sleep(2000);

            //try
            //{
            //        Assert
            //}
            //catch (Exception ex) 
            //{

            //}

        }

    }
}
