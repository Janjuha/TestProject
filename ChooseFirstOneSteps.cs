using Booking_Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Booking_Project
{
    [Binding]
    public class ChooseFirstOneSteps
    {
        static IWebDriver driver = new ChromeDriver();
        MainPage mainPage = new MainPage(driver);
        SignInPage signInPage = new SignInPage(driver);
        RegisteredMainPage regMainPage = new RegisteredMainPage(driver);


        [Given(@"I have account created")]
        public void GivenIHaveAccountCreated()
        {
            CustomMethods.GoToURL(driver, "https://booking.com");
            mainPage.ChooseDefaultSettings();
            mainPage.GoToSignInPage();

            signInPage.TypeCredentials();
            Thread.Sleep(5000);
            CustomMethods.AcceptCookie(driver);
        }
        
        [Given(@"I am in '(.*)' page")]
        public void GivenIAmInPage(string page)
        {
            Console.WriteLine($"Im on {page} page");
        }
        
        [When(@"I set up destination as '(.*)'")]
        public void WhenISetUpDestinationAs(string destination)
        {
            regMainPage.Destination.Click();
            regMainPage.Destination.Clear();
            regMainPage.SetDestination(destination);
            Thread.Sleep(1000);
            Assert.AreEqual(destination, regMainPage.GetDestionationText());
            regMainPage.ClickOnDestionation();
            Thread.Sleep(1000);
        }
        
        [When(@"I set dates '(.*)' - '(.*)'")]
        public void WhenISetDates_(string startDate, string endDate)
        {
            Thread.Sleep(200);
            CustomMethods.clickOnDate(driver, CustomMethods.ChangeFormat(startDate));
            CustomMethods.clickOnDate(driver, CustomMethods.ChangeFormat(endDate));
        }
        
        [When(@"I select '(.*)' adults and '(.*)' children")]
        public void WhenISelectAdultsAndChildren(int adults, int children)
        {
            regMainPage.OpenGuestPanel();
            regMainPage.SelectAdultPeople(adults);
            regMainPage.SelectChildren(children);
        }
        
        [When(@"I click on Search button")]
        public void WhenIClickOnButton()
        {
            regMainPage.SearchHotel();
        }
        
        [When(@"I click on '(.*)' for fist hotel in the list")]
        public void WhenIClickOnForFistHotelInTheList(string p0)
        {
            Console.WriteLine("test");
        }
        
        [When(@"'(.*)' page is opened for selected hotel")]
        public void WhenPageIsOpenedForSelectedHotel(string p0)
        {
            Console.WriteLine("test");
        }
        
        [When(@"I click on '(.*)' button for recommended room")]
        public void WhenIClickOnButtonForRecommendedRoom(string p0)
        {
            Console.WriteLine("test");
        }
        
        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnLlReserveButton(string p0)
        {
            Console.WriteLine("test");
        }
        
        [Then(@"'(.*)' page is displayed")]
        public void ThenPageIsDisplayed(string p0)
        {
            Console.WriteLine("test");
        }
        
        [Then(@"I enter valid booking information")]
        public void ThenIEnterValidBookingInformation()
        {
            Console.WriteLine("test");
        }
        
        [Then(@"I click on '(.*)' button")]
        public void ThenIClickOnButton(string p0)
        {
            Console.WriteLine("test");
        }
    }
}
