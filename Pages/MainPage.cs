using Booking_Project.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Project
{
    class MainPage
    {
        private IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/ul/li[2]")]
        public IWebElement LngElement { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/ul/li[2]/div/div[2]/div/div[1]/div/ul[2]/li[2]")]
        public IWebElement EnglishLng { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='user_form']/ul/li[1]")]
        public IWebElement CurrencyElement { get; set; }

        //************************************************

        [FindsBy(How = How.XPath, Using = "//*[@id='currency_dropdown_top']/ul[1]/li[1]")]
        public IWebElement USDCurrency { get; set; }

        [FindsBy(How = How.Id, Using = "current_account_create")]
        public IWebElement RegisterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "current_account")]
        public IWebElement SignInBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile-menu > div.profile-menu__item.profile_menu__item--mydashboard")]
        public IWebElement MyDashboard { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dashboard_container > div > div > div.db_data_content_area.dashboard_height_auto_adjust.dashboard-content-setion > div.email-confirm-banner > div.email-confirm-banner__right > div.email-confirm-banner__resend-block > div.email-confirm-banner__email > input")]
        public IWebElement DashboardEmailInput { get; set; }

        public void ChooseDefaultSettings()
        {
            LngElement.Click();
            EnglishLng.Click();
            //System.Threading.Thread.Sleep(1000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CurrencyElement.Click();
            //System.Threading.Thread.Sleep(1000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='currency_dropdown_top']/ul[1]/li[1]")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (!USDCurrency.GetAttribute("class").Contains("selected_currency"))
            {
                USDCurrency.Click();
            } else
            {
                CurrencyElement.Click();
            }
        }
        public void GotToRegisterPage()
        {
            RegisterBtn.Click();
        }

        public void GoToSignInPage()
        {
            SignInBtn.Click();
        }
    }
}
