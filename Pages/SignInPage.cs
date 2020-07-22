using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking_Project.Pages
{
    class SignInPage
    {
        private IWebDriver driver;
        public string email = "janjuha1@gmail.com";
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement InputUsername { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement InputPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div[2]/div/div/div/form/button")]
        public IWebElement SignInBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div[2]/div/div/div/form/div[3]/button")]
        public IWebElement NextBtn { get; set; }



        public void TypeCredentials()
        {
            //Thread.Sleep(1000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            InputUsername.SendKeys(email);
            NextBtn.Click();
            //Thread.Sleep(1000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            InputPassword.SendKeys("Webapp!1");
            SignInBtn.Click();
        }
    }
}
