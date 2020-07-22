using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Booking_Project
{
    [Binding]
    public class CreateAccountSteps
    {
        static IWebDriver driver = new ChromeDriver();
        MainPage mainPage = new MainPage(driver);
        RegisterPage registerPage = new RegisterPage(driver);

        [Given(@"I am in Sign Up page")]
        public void GivenIAmInSignUpPage()
        {
            CustomMethods.GoToURL(driver, "https://booking.com");
            mainPage.ChooseDefaultSettings();
            mainPage.GotToRegisterPage();
        }
        
        [When(@"I enter valid user email")]
        public void WhenIEnterValidUserEmail()
        {
            //Thread.Sleep(1000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            registerPage.TypeEmail();
        }
        
        [When(@"click on “GET STARTED” button")]
        public void WhenClickOnGETSTARTEDButton()
        {
            registerPage.PressStart();
        }
        
        [When(@"I enter valid password")]
        public void WhenIEnterValidPassword()
        {
            //Thread.Sleep(1000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            registerPage.TypePassword();
        }
        
        [When(@"click on “Create Account” button")]
        public void WhenClickOnCreateAccountButton()
        {
            Console.WriteLine("test");
        }
        
        [When(@"main page is opened")]
        public void WhenMainPageIsOpened()
        {
            Console.WriteLine("test");
        }
        
        [When(@"I click on “My Dashboard” button under account menu")]
        public void WhenIClickOnMyDashboardButtonUnderAccountMenu()
        {
            Console.WriteLine("test");
        }
        
        [Then(@"“My Dashboard” page is opened")]
        public void ThenMyDashboardPageIsOpened()
        {
            Console.WriteLine("test");
        }
        
        [Then(@"correct value is prefilled in email verification placeholder")]
        public void ThenCorrectValueIsPrefilledInEmailVerificationPlaceholder()
        {
            Console.WriteLine("test");
        }
    }
}
