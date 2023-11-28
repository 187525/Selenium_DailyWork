
using UrbanLadder.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.PageObjects;



namespace UrbanLadder.TestScripts
{
    internal class BuyingProduct :CoreCodes
    {
        [Test]
        [Order(1), Category("Regression Testing")]
        public void SearchProductTest()
        {
            var homepage = new ULHomePage(driver);
            if (!driver.Url.Contains("https://www.urbanladder.com/"))
            {
                driver.Navigate().GoToUrl("https://www.urbanladder.com/");
            }
            string currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string sheetName = "SearchProduct";
            List<ExcelData> productDataList = ExcelUtilities.ReadExcelData(excelFilePath, sheetName);
            foreach (var productData in productDataList)
            {
                string productName = productData.ProductName;
                Console.WriteLine($"Product Name:{productName}");
                homepage.TypeSearchBox(productName);
                TakeScreenShot();
            }

            
            var selectproductlist = new SearchProductListPage(driver);
            selectproductlist.ClickSeclectedProduct();
            Thread.Sleep(5000);
            TakeScreenShot();

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            TakeScreenShot();

            var buyProduct = new SearchProduct(driver);
            buyProduct.ClickCloseBtn();
            Thread.Sleep(1000);


            buyProduct.SizeSelect();
            Thread.Sleep(1000);
            buyProduct.ThicknessSelect();
            Thread.Sleep(1000);
            buyProduct.ClickBuyNow();
            TakeScreenShot();
            Thread.Sleep(1000);

            //var cart = new Cart(driver);

            //cart.ClickIncrement("2");
            //TakeScreenShot();

            //Thread.Sleep(3000);
            //cart.ClickRemove();
            //TakeScreenShot();
            //Thread.Sleep(1000);
            //try
            //{
            //    IWebElement value = driver.FindElement(By.XPath("//*[@id=\"ShoppingCartPopup\"]/div[2]/span"));
            //    Assert.AreEqual(value.Text, "You have No Items in Cart !!!");
            //    test = extent.CreateTest("Remove item from cart - Pass");
            //    test.Pass("Remove item from cart success");
            //    Console.WriteLine("ERCP");
            //}
            //catch
            //{
            //    test = extent.CreateTest(" Remove item from cart- Fail");
            //    test.Fail("Remove item from cart fail");
            //    Console.WriteLine("ERCF");
            //}

            //Thread.Sleep(1000);

            //buyProduct.ClickClose();
            //Thread.Sleep(1000);

        }
    }
}
    

