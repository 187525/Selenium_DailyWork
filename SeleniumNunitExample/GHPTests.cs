using OpenQA.Selenium;
using SeleniumNunitExample;
using SeleniumNUnitExample;
using SeleniumNUnitExamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture]
    internal class GHPTests : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(0)]
        public void TitleTest()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        
        [Test]
        [Order(1)]
        public void GSTests()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currDir + "\\InputData.xlsx";
            Console.Write(excelFilePath);   

            List<ExcelData> excelDataList= ExcelUtils.ReadExcelData(excelFilePath); 

            foreach(var excelData in excelDataList)
            {
                Console.WriteLine($"Text:{excelData.SearchText}");

                IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
                searchinputtextbox.SendKeys(excelData.SearchText);
                Thread.Sleep(5000);
                //IWebElement gsButton = driver.FindElement(By.Name("btnK"));
                IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
                gsbutton.Click();
                Assert.That(driver.Title, Is.EqualTo(excelData.SearchText +" - Google Search"));
                Console.WriteLine("GS TEST - Pass");
            }
            
        }
        [Ignore("other")]
        [Test]
       
        public void AllLinkStatusTest()
        {
            List<IWebElement> alllinks = driver.FindElements(By.TagName("a")).ToList();
            foreach(var link in alllinks) 
            {
                string url=link.GetAttribute("href");   
                if(url==null)
                {
                    Console.WriteLine("url is null");
                    continue;
                }
                else
                {
                    bool isworking = ChechLinkStatus(url);
                    if(isworking)
                    {
                        Console.WriteLine(url + "is working");
                    }
                    else
                    {
                        Console.WriteLine(url + "is NOT working");
                    }
                }

            }
        }
    }
}