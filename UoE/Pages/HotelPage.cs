using UoE.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using NUnit.Framework;
using System.Linq;

namespace UoE.Pages
{
    class HotelPage
    {
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;
        public HotelPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        [FindsBy(How = How.Id, Using = "hp_book_now_button")]
        public IWebElement reserveButton;

        [FindsBy(How = How.CssSelector, Using = "[class='hprt-reservation-cta']")]
        public IWebElement iWillReserveTab;

        [FindsBy(How = How.Id, Using = "hprt_nos_select_bbasic_")]
        public IWebElement selectRoom;
        public SelectElement selectRoomType;

        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement firstNameField;

        [FindsBy(How = How.Id, Using = "lastname")]
        public IWebElement lastNameField;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement emailField;

        [FindsBy(How = How.Id, Using = "email_confirm")]
        public IWebElement confirmEmailField;

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement phoneField;

        [FindsBy(How = How.CssSelector, Using = "[type='submit'][name='book']")]
        public IWebElement nextButton;

        [FindsBy(How = How.CssSelector, Using = "[class='bui-button bui-button--primary bui-button--large js-submit_holder_button bp-overview-buttons-submit  bp-button'][name='book']")]
        public IWebElement completeBookingButton;




        public void IClickReserveButton()
        {
            string newWin = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newWin);
            reserveButton.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

        public void ISelectRoomType()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selectRoom));
            selectRoomType = new SelectElement(selectRoom);
            selectRoomType.SelectByValue("1");
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }        

        public void IClickWillReserveTab()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(iWillReserveTab));
            iWillReserveTab.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

        public void IEnterMyDetails()
        {
            string mail = "Test@gmail.com";
            firstNameField.SendKeys("Ky");
            lastNameField.SendKeys("Demo");
            emailField.SendKeys(mail);
            confirmEmailField.SendKeys(mail);
            phoneField.SendKeys("07777777777");
            nextButton.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }
        public void IAssertPaymentPage()
        {
            Assert.IsTrue(_driver.Url.Contains("https://secure.booking.com/"));
            Assert.IsTrue(completeBookingButton.Displayed);
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }
    }
}
