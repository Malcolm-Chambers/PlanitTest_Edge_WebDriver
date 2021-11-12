using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace PlanitTest_Edge_WebDriver
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private EdgeDriver _driver;

        [TestInitialize]

        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
//            _driver = new EdgeDriver($"D:/Projects/WebDriver/");
            _driver = new EdgeDriver($"D:/Projects/Planit/PlanitTest_Edge_WebDriver/WebDriver");
        }

        [TestMethod]
        public void GuardTestAbleToAccessWebSite()
        {
            // Replace with your own test logic
            _driver.Url = "https://jupiter.cloud.planittesting.com/#/home";
            Assert.AreEqual("Jupiter Toys", _driver.Title);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            if (_driver != null)
                _driver.Quit();
        }
    }
}
