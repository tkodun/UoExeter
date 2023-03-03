using UoE.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace UoE.Pages
{
    class LandingPage
    {
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;
        public LandingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        [FindsBy(How = How.Id, Using = "onetrust-button-group")]
        public IWebElement cookiesButton;

        [FindsBy(How = How.Id, Using = ":Ra9:")]
        public IWebElement whereToField;

        [FindsBy(How = How.CssSelector, Using = "[type='button'][data-testid='date-display-field-start']")]
        public IWebElement checkInDateField;

        [FindsBy(How = How.CssSelector, Using = "[data-date='2023-03-20']")]
        public IWebElement selectCheckInDate;

        [FindsBy(How = How.CssSelector, Using = "[type='button'][data-testid='date-display-field-end']")]
        public IWebElement checkOutDateField;

        [FindsBy(How = How.CssSelector, Using = "[data-date='2023-03-23']")]
        public IWebElement selectCheckOutDate;

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement searchButton;


        public void IClickCookiesButton()
        {
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(cookiesButton));
            cookiesButton.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

        public void IEnterDestination()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(whereToField));
            whereToField.SendKeys("Manchester");
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

        public void ISelectCheckInTime()
        {
            checkInDateField.Click();
            selectCheckInDate.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

        public void ISelectCheckOutTime()
        {
            selectCheckOutDate.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

        public void IClickSearchButton()
        {
            searchButton.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }


    }
}
