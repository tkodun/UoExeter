using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace UoE.Helpers
{
    class BaseClass
    {
        public static IWebDriver _driver { get; set; }
        public static SelectElement select;
        public static WebDriverWait _wait;

        static BaseClass()
        {
            _driver = null;
            select = null;
            _wait = null;
        }

        public static bool WaitForElement(By by, int numberOfTrysToDisplayElement = 35)
        {
            bool hasElementBeenHidden = false;
            for (int retryCount = 0; retryCount < numberOfTrysToDisplayElement; retryCount++)
            {
                try
                {
                    _wait.Until(webDriver => (_driver.FindElement(by).Displayed == false));
                    hasElementBeenHidden = true;
                    break;
                }
                catch (Exception)
                {
                    hasElementBeenHidden = false;
                }
            }
            return hasElementBeenHidden;
        }

        public static void waitForAjax()
        {
            //bool condition = true;
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            string scriptToExecute = "return typeof jQuery != 'undefined' && jQuery.active === 0";
            while (true)
            {
                //if (sw.Elapsed.Seconds > timeOut)
                //    throw new Exception("Timeout");
                var AjaxIsComplete = (bool)((IJavaScriptExecutor)_driver).ExecuteScript(scriptToExecute);
                if (AjaxIsComplete)
                    break;
                Thread.Sleep(1000);
            }
        }


        public static void waitForJQueryToBeActive()
        {
            bool isJqueryUsed = (bool)((IJavaScriptExecutor)_driver)
                    .ExecuteScript("return (typeof(jQuery) != 'undefined')");
            if (isJqueryUsed)
            {
                while (true)
                {
                    // JavaScript test to verify jQuery is active or not
                    bool ajaxIsComplete = (bool)(((IJavaScriptExecutor)_driver)
                            .ExecuteScript("return jQuery.active == 0"));
                    if (ajaxIsComplete)
                        break;
                    try
                    {
                        Thread.Sleep(1000);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }

}

