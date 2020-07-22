using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Project
{
    class RegisteredMainPage
    {
        private IWebDriver driver;
        public RegisteredMainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "current_account")]
        public IWebElement Profile { get; set; }

        [FindsBy(How = How.Id, Using = "ss")]
        public IWebElement Destination { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]")]
        public IWebElement FirstMatchedDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]/span[2]/span")]
        public IWebElement FirstMatchedDestionationSpan { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/div[1]/div[2]")]
        public IWebElement DatePicker { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.sb-group__field:nth-child(1) > div:nth-child(1) > div:nth-child(2) > span:nth-child(3)")]
        public IWebElement DefaultAdultElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#xp__guests__inputs-container > div > div > div.sb-group__field.sb-group-children > div > div.bui-stepper__wrapper.sb-group__stepper-a11y > span.bui-stepper__display")]
        public IWebElement DefaultChildrenElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.sb-group__field:nth-child(1) > div:nth-child(1) > div:nth-child(2) > button:nth-child(4)")]
        public IWebElement PlusSignBtnAdults { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.sb-group__field:nth-child(1) > div:nth-child(1) > div:nth-child(2) > button:nth-child(2)")]
        public IWebElement MinusSignBtnAdults { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#xp__guests__inputs-container > div > div > div.sb-group__field.sb-group-children > div > div.bui-stepper__wrapper.sb-group__stepper-a11y > button.bui-button.bui-button--secondary.bui-stepper__add-button")]
        public IWebElement PlusSignBtnChildren { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#xp__guests__inputs-container > div > div > div.sb-group__field.sb-group-children > div > div.bui-stepper__wrapper.sb-group__stepper-a11y > button.bui-button.bui-button--secondary.bui-stepper__subtract-button.sb-group__stepper-button-disabled")]
        public IWebElement MinusSignBtnChildren { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/div[1]/div[3]")]
        public IWebElement GuestPanel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/div[1]/div[4]/div[2]/button")]
        public IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b2indexPage']/div[25]/button")]
        public IWebElement ClosePopupBtn { get; set; }

        public void GoToProfile()
        {
            Profile.Click();
        }

        public void ClosePopUpWindow()
        {
            ClosePopupBtn.Click();
        }

        public void SetDestination(string destination)
        {
            Destination.SendKeys(destination);
        }

        public string GetDestionationText()
        {
            return FirstMatchedDestionationSpan.Text;
        }

        public void ClearInputField()
        {
            FirstMatchedDestionationSpan.Clear();
        }

        public void ClickOnDestionation()
        {
            FirstMatchedDestination.Click();
        }

        public void OpenDatePicker()
        {
            DatePicker.Click();
        }

        public void OpenGuestPanel()
        {
            GuestPanel.Click();
        }

        public void SelectAdultPeople(int adults)
        {
            var people = DefaultAdultElement.Text;
            int peopleCount = Int32.Parse(people);
            while (peopleCount != adults)
            {
                if (peopleCount < adults)
                {
                    PlusSignBtnAdults.Click();
                    peopleCount++;
                }
                else if (peopleCount > adults)
                {
                    MinusSignBtnAdults.Click();
                    peopleCount--;
                }
                else
                {
                    peopleCount = adults;
                }
            }
        }

        public void SelectChildren(int children)
        {
            var people = DefaultChildrenElement.Text;
            int peopleCount = Int32.Parse(people);
            while (peopleCount != children)
            {
                if (peopleCount < children)
                {
                    PlusSignBtnChildren.Click();
                    peopleCount++;
                }
                else if (peopleCount > children)
                {
                    MinusSignBtnChildren.Click();
                    peopleCount--;
                }
                else
                {
                    peopleCount = children;
                }
            }
        }

        public void SearchHotel()
        {
            SearchBtn.Click();
        }
    }
}

