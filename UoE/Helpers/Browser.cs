using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace UoE.Helpers
{
    class Browser
    {
        static IWebDriver _driver;
        public static IWebDriver Startbrowser(String browserName, string url)
        {
            if (browserName.Equals("firefox"))
            {
                _driver = new FirefoxDriver();
                _driver.Manage().Window.Maximize();
                _driver.Manage().Cookies.DeleteAllCookies();
            }
            else if (browserName.Equals("chrome"))
            {
                ChromeOptions options = new ChromeOptions();
                // options.PageLoadStrategy = PageLoadStrategy.None;
                options.AddArguments("disable-popup-blocking", "true");
                //options.AddArguments("headless");
                _driver = new ChromeDriver(options);
                _driver.Manage().Window.Maximize();
                _driver.Manage().Cookies.DeleteAllCookies();
            }
            _driver.Navigate().GoToUrl(url);
            return _driver;
        }
    }
}
