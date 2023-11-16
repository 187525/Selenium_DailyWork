

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelExamples;

AmazonTests az = new AmazonTests();

List<string> drivers=new List<string>();
//drivers.Add("InitializeEdgeDriver()");
drivers.Add("Chrome");

//Console.WriteLine("1.Edge 2.Chrome");
//int ch = Convert.ToInt32(Console.ReadLine());
foreach(var d in drivers)
{

    
    switch (d)
    {
        //case "Edge":
            //az.InitializeEdgeDriver(); break;
        case "Chrome":
             az.InitializeChromeDriver(); break;
    }



    try
    {
        //az.TiltleTest();
        //az.LogoClickTest();
        //Thread.Sleep(2000);
        //az.SearchProductTest(); 
        //az.SignInAccListTest();
        az.SearchAndFilterProductByBrandtest();
       

    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }

   az.Destruct();
}