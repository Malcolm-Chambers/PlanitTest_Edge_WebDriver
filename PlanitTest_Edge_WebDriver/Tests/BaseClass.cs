using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace PlanitTest_Edge_WebDriver
{
    [TestClass]
    public class BaseTest
    {

        protected EdgeDriver _driver;
        protected WebDriverWait wait;

        [TestInitialize]

        public virtual void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver($"D:/Projects/Planit/PlanitTest_Edge_WebDriver/WebDriver");
            wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));

        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            if (_driver != null)
                _driver.Quit();
        }
    }
}
