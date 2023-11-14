using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelAssignment;

NavigationTest navigateTests = new NavigationTest();
navigateTests.InitializeChromeDriver();

try
{
    navigateTests.GoogleSearchTest();
    navigateTests.DiwaliSearchTest();
}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}

navigateTests.Destruct();

/*AmazonTest amazonTests= new AmazonTest();   
amazonTests.InitializeChromeDriver();
try
{
    amazonTests.TitleTest();
    amazonTests.OrganizationType();

}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}

amazonTests.Destruct();*/


