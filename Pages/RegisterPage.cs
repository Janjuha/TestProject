using Booking_Project.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Project
{
    class RegisterPage
    {
        private IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "login_name_register")]
        public IWebElement InputFieldEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div[1]/div[2]/div/div/div/form/button")]
        public IWebElement GetStarted { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement InputPassword { get; set; }

        [FindsBy(How = How.Name, Using = "confirmed_password")]
        public IWebElement ConfirmPassword { get; set; }

        public void TypeEmail()
        {
            InputFieldEmail.SendKeys("janjuha2@gmail.com");
        }

        public void PressStart()
        {
            GetStarted.Click();
        }

        public void TypePassword()
        {
            InputPassword.SendKeys("12345678");
            ConfirmPassword.SendKeys("12345678");
        }
    }
}
