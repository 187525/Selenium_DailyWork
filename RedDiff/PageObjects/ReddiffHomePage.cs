using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDiff.PageObjects
{
    internal class ReddiffHomePage
    {
        IWebDriver driver;
        public ReddiffHomePage(IWebDriver? driver) //writing constructor
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this); //pagefactory-it is a collection of all the page elements that are provided inside page class.Initelements-to initiate all the elements in 'this',here this refers to driver.that is,currectnt driver,homepage
        }

        //ARRANGE
        //properties

        [FindsBy(How = How.LinkText, Using = "Create Account")] //how to find create acc element
        public IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in")] //FindsBy is an attiribute
        public IWebElement? SignInLink { get; set; }

        //ACT
        //we should write action methods here

        //public void CreateAccountLinkClick()
        //{
        //    CreateAccountLink?.Click();

        //}

        //public void SignInLinkClick()
        //{
        //    SignInLink?.Click();
        //}

        public CreateAccountPage CreateAccountClick()
        {
            CreateAccountLink?.Click();
            return new CreateAccountPage(driver); //returning createaccountpage object.
        }

        public SigninPage SignInClick()
        {
            SignInLink?.Click();
            return new SigninPage(driver); //returning createaccountpage object.
        }
    }
}
