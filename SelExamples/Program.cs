

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelExamples;

GHPTests gHTests = new GHPTests();

List<string> drivers=new List<string>();
drivers.Add("InitializeEdgeDriver()");
drivers.Add("InitializeGoogleDriver()");

/*Console.WriteLine("1.Edge 2.Chrome");
int ch = Convert.ToInt32(Console.ReadLine());
switch (ch)
{
    case 1:
        gHTests.InitializeEdgeDriver(); break;
    case 2:
        gHTests.InitializeChromeDriver(); break;
}*/
foreach (var d in drivers)
{


    try
    {
        gHTests.TitleTest();
        gHTests.PageSourceandURLTest();
        gHTests.GoogleSearchTest();
        gHTests.GmailLinkTest();
        gHTests.ImagesLinkTest();


    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }

    gHTests.Destruct();
}