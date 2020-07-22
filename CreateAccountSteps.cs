using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Runtime.InteropServices;
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
        RegisteredMainPage registeredPage = new RegisteredMainPage(driver);

        [Given(@"I am in Sign Up page")]
        public void GivenIAmInSignUpPage()
        {
            CustomMethods.GoToURL(driver, "https://booking.com");
            mainPage.ChooseDefaultSettings();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual("Booking.com | Official site | The best hotels & accommodations", driver.Title);
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
            registerPage.CreateAccount();
        }
        
        [When(@"main page is opened")]
        public void WhenMainPageIsOpened()
        {
            Console.WriteLine("Main Page is Opened");
            CustomMethods.AcceptCookie(driver);
            //Here I'm cheating, because time to time there are random banners for the new registered clients,
            //I'm just refreshing the page 2 times to skip them :(
            for (int i = 0; i < 2; i++)
            {
                driver.Navigate().Refresh();
            }
        }
        
        [When(@"I click on “My Dashboard” button under account menu")]
        public void WhenIClickOnMyDashboardButtonUnderAccountMenu()
        {
            mainPage.SignInBtn.Click();
            //Thread.Sleep(2000);
            mainPage.MyDashboard.Click();
        }
        
        [Then(@"“My Dashboard” page is opened")]
        public void ThenMyDashboardPageIsOpened()
        {
            Console.WriteLine("My Dashboard is opened");
        }
        
        [Then(@"correct value is prefilled in email verification placeholder")]
        public void ThenCorrectValueIsPrefilledInEmailVerificationPlaceholder()
        {
            Assert.AreEqual(registerPage.registerEmail, mainPage.DashboardEmailInput.GetAttribute("value"));
            driver.Close();
        }
    }
}
