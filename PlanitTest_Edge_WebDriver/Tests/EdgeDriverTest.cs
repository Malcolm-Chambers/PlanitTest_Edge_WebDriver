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
        }
        [TestMethod]
        public void GuardTestAbleToAccessWebContact()
        {
            // Replace with your own test logic
            _driver.Url = Urls.Contact;
            Assert.AreEqual("Jupiter Toys", _driver.Title);
        }

        [TestMethod]
        public void GuardContract_InteractableFields()
        {
            // Arrange
            _driver.Url = Urls.Contact;

            // Act
            _driver.FindElement(By.ClassName("btn-contact"));
            _driver.FindElement(By.Id("forename"));
            _driver.FindElement(By.Id("surname"));
            _driver.FindElement(By.Id("email"));
            _driver.FindElement(By.Id("telephone"));
            _driver.FindElement(By.Id("message"));

            // Assert
            // No Exceptions IE all fields found.
        }
        [TestMethod]
        public void GuardContract_Labels()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            // Act
            var btn = _driver.FindElement(By.ClassName("btn-contact"));
            btn.Click();
            var forenameLabel = _driver.FindElement(By.XPath("/html/body/div[2]/div/form/fieldset/div[1]/label"));
            var forenameHelp = _driver.FindElement(By.XPath("/html/body/div[2]/div/form/fieldset/div[1]/div/span"));
            var c= forenameHelp.GetCssValue("color");
            // Assert
            Assert.AreEqual("Forename *", forenameLabel.Text);
            Assert.AreEqual("Forename is required", forenameHelp.Text);
            Assert.AreEqual("rgba(185, 74, 72, 1)", forenameHelp.GetCssValue("color"));
            // No Exceptions IE all fields found.
        }
    }
}
