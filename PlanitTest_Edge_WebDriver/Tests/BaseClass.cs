using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace PlanitTest_Edge_WebDriver
{
    [TestClass]
    public class BaseTest
    {

        protected EdgeDriver _driver;

        [TestInitialize]

        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver($"D:/Projects/Planit/PlanitTest_Edge_WebDriver/WebDriver");
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            if (_driver != null)
                _driver.Quit();
        }
    }
}
