using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UoE.Helpers;
using UoE.Pages;

namespace UoE.StepDefinitions
{
    [Binding]
    public class E2EBookingSteps : IDisposable
    {
        IWebDriver driver = null;
        string baseUrl = "https://www.booking.com/" ;


        [Given(@"I am on the landing page")]
        public void GivenIAmOnTheLandingPage()
        {
            driver = Browser.Startbrowser("chrome", baseUrl);
        }


        [Given(@"I accept the cookies")]
        public void GivenIAcceptTheCookies()
        {           
            LandingPage land = new LandingPage(driver);
            land.IClickCookiesButton();
            BaseClass.WaitForElement(By.CssSelector("#loading"), 1);
        }

        [Given(@"I enter destination as Manchester")]
        public void GivenIEnterDestinationAsManchester()
        {
            LandingPage land = new LandingPage(driver);
            land.IEnterDestination();
        }

        [Given(@"I select the check in and out date")]
        public void GivenISelectTheCheckInAndOutDate()
        {
            LandingPage land = new LandingPage(driver);
            land.ISelectCheckInTime();
            land.ISelectCheckOutTime();
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            LandingPage land = new LandingPage(driver);
            land.IClickSearchButton();
        }

        [Then(@"I select first hotel in list")]
        public void ThenISelectFirstHotelInList()
        {
            SearchResultPage result = new SearchResultPage(driver);
            result.ISelectSeeAvailability();
        }

        [Then(@"I click on reserve button in new window")]
        public void ThenIClickOnReserveButtonInNewWindow()
        {
            HotelPage hotel = new HotelPage(driver);
            hotel.IClickReserveButton();
        }

        [Then(@"I select room type")]
        public void ThenISelectRoomType()
        {
            HotelPage hotel = new HotelPage(driver);
            hotel.ISelectRoomType();
        }


        [Then(@"I click I will reserve button")]
        public void ThenIClickIWillReserveButton()
        {
            HotelPage hotel = new HotelPage(driver);
            hotel.IClickWillReserveTab();
        }

        [Then(@"I enter my details")]
        public void ThenIEnterMyDetails()
        {
            HotelPage hotel = new HotelPage(driver);
            hotel.IEnterMyDetails();
        }

        [Then(@"I assert the payment page is displayed")]
        public void ThenIAssertThePaymentPageIsDisplayed()
        {
            HotelPage hotel = new HotelPage(driver);
            hotel.IAssertPaymentPage();
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}
