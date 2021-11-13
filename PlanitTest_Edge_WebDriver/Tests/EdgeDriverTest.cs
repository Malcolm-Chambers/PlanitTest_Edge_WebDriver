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
            _driver.FindElement(By.ClassName(LocatorsInContact.SubmitButton));
            _driver.FindElement(By.Id(LocatorsInContact.forename));
            _driver.FindElement(By.Id(LocatorsInContact.surname));
            _driver.FindElement(By.Id(LocatorsInContact.email));
            _driver.FindElement(By.Id(LocatorsInContact.telephone));
            _driver.FindElement(By.Id(LocatorsInContact.message));

            // Assert
            // No Exceptions IE all fields found.
        }
        [TestMethod]
        public void GuardContract_Labels()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            // Act
            var forenameLabel = _driver.FindElement(By.XPath(LocatorsInContact.forenameLabel));
            var surnameLabel = _driver.FindElement(By.XPath(LocatorsInContact.surnameLabel));
            var emailLabel = _driver.FindElement(By.XPath(LocatorsInContact.emailLabel));
            var telephoneLabel = _driver.FindElement(By.XPath(LocatorsInContact.telephoneLabel));
            var messageLabel = _driver.FindElement(By.XPath(LocatorsInContact.messageLabel));
            // Assert
            Assert.AreEqual("Forename *", forenameLabel.Text);
            Assert.AreEqual("Surname *", surnameLabel.Text);
            Assert.AreEqual("Email *", emailLabel.Text);
            Assert.AreEqual("Telephone *", telephoneLabel.Text);
            Assert.AreEqual("Message *", messageLabel.Text);
            // No Exceptions IE all fields found.
        }
        [TestMethod]
        public void GuardContract_ErrorHelps()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            // Act Trigger errors to cause Error help to bediscoverable
            var btn = _driver.FindElement(By.ClassName("btn-contact"));
            btn.Click();

            var forenameHelp = _driver.FindElement(By.XPath(LocatorsInContact.forenameHelp));
            var emailHelp = _driver.FindElement(By.XPath(LocatorsInContact.emailHelp));
            var messageHelp = _driver.FindElement(By.XPath(LocatorsInContact.messageHelp));
            // Assert
            Assert.AreEqual("Forename is required", forenameHelp.Text);
            Assert.AreEqual("Email is required", emailHelp.Text);
            Assert.AreEqual("Message is required", messageHelp.Text);
        }
    }
}
