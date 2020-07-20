using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking_Project
{
    class CustomMethods
    {
        public static void GoToURL(IWebDriver driver, string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public static void InputText(IWebDriver driver, string element, string path, string text)
        {
            if (path == "Id")
                driver.FindElement(By.Id(element)).SendKeys(text);
            if (path == "Xpath")
                driver.FindElement(By.XPath(element)).SendKeys(text);
            if (path == "CSS")
                driver.FindElement(By.CssSelector(element)).SendKeys(text);
            if (path == "Name")
                driver.FindElement(By.Name(element)).SendKeys(text);
        }

        public static string GetTitle(IWebDriver driver)
        {
            return driver.Title;
        }

        public static void AcceptCookie(IWebDriver driver)
        {
            if (driver.FindElements(By.XPath("//*[@id='cookie_warning']/div/div/div[2]/button")).Count == 0) {
                driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            } else
            driver.FindElement(By.XPath("//*[@id='cookie_warning']/div/div/div[2]/button")).Click();
        }

        public static void Click(IWebDriver driver, string element, string path)
        {
            if (path == "Id")
                driver.FindElement(By.Id(element)).Click();
            if (path == "Xpath")
                driver.FindElement(By.XPath(element)).Click();
            if (path == "CSS")
                driver.FindElement(By.CssSelector(element)).Click();
        }

        public static string ChangeFormat(string input)
        {
            string date = input;
            var splitted = date.Split('-');
            var newDate = splitted[2] + "-" + splitted[1] + "-" + splitted[0];
            return newDate;
        }

        public static void clickOnDate(IWebDriver driver, string dateToClick)
        {
            bool isDisplayed = false;

            while (isDisplayed != true)
            {
                if (driver.FindElements(By.XPath($"//td[@data-date='{dateToClick}']/span/span")).Count != 0)
                {
                    driver.FindElement(By.XPath($"//td[@data-date='{dateToClick}']/span/span")).Click();
                    isDisplayed = true;
                }
                else
                {
                    driver.FindElement(By.CssSelector("#frm > div.xp__fieldset.accommodation > div.xp__dates.xp__group > div.xp-calendar > div > div > div.bui-calendar__control.bui-calendar__control--next")).Click();
                }
            }
        }
    }
}