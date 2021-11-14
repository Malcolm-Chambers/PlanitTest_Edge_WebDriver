using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PlanitTest_Edge_WebDriver.Helpers;

namespace PlanitTest_Edge_WebDriver
{
    [TestClass]
    public class GuardTests : BaseTest
    {
        [TestMethod]
        public void GuardTestAbleToAccessWebHome()
        {
            // Replace with your own test logic
            _driver.Url = Urls.Home;
            Assert.AreEqual("Jupiter Toys", _driver.Title);
            // Verify that the Home button is highlighted in menu
        }
        [TestMethod]
        public void GuardTestAbleToAccessWebContact()
        {
            // Replace with your own test logic
            _driver.Url = Urls.Contact;
            Assert.AreEqual("Jupiter Toys", _driver.Title);
            // Verify that the Contact button is highlighted in menu
        }

        [TestMethod]
        public void GuardTestAbleToAccessWebShop()
        {
            // Replace with your own test logic
            _driver.Url = Urls.Shop;
            Assert.AreEqual("Jupiter Toys", _driver.Title);
            // Verify that the Shop button is highlighted in menu
        }

        [TestMethod]
        public void GuardTestAbleToAccessWebCart()
        {
            // Replace with your own test logic
            _driver.Url = Urls.Cart;
            Assert.AreEqual("Jupiter Toys", _driver.Title);
            // Verify that the Cart button is highlighted in menu
        }
    }
}
