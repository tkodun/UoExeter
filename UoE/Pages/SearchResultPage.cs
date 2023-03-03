using UoE.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace UoE.Pages
{
    class SearchResultPage
    {
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;
        public SearchResultPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        [FindsBy(How = How.CssSelector, Using = "[data-testid='availability-cta']")]
        public IWebElement seeAvailability;


        public void ISelectSeeAvailability()
        {
            seeAvailability.Click();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

    }
}
