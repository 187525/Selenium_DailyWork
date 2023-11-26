using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BunnyCart.PageObjects
{
    internal class SearchResultPage
    {

        IWebDriver driver;

        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement? FirstProductLink { get; set; }

        public string? GetFirstProductLInk()
        {
            return FirstProductLink?.Text;
        }
        public ProductPage ClickFirstProductLink()
        {
            FirstProductLink?.Click();
            return new ProductPage(driver);

        }

    }
}
