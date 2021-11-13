using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PlanitTest_Edge_WebDriver.Helpers;

namespace PlanitTest_Edge_WebDriver
{
    [TestClass]
    public class ContactsPage : BaseTest
    {
        #region Test Case 1
        [TestMethod]
        public void Contacts_PressSubmit_MissingDefaults()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            var SubmitButton = _driver.FindElement(By.ClassName("btn-contact"));
            // Act
            SubmitButton.Click();

            // Assert
            IWebElement forename = _driver.FindElement(By.Id(LocatorsInContact.forename));
            IWebElement forenameLabel = _driver.FindElement(By.XPath(LocatorsInContact.forenameLabel));
            IWebElement forenameHelp = _driver.FindElement(By.XPath(LocatorsInContact.forenameHelp));

            Assert.AreEqual(Formats.ErrorBorderRed, forename.GetCssValue("border-color"));
            Assert.AreEqual(Formats.ErrorRed, forename.GetCssValue("color"));
            Assert.AreEqual(Formats.ErrorRed, forenameLabel.GetCssValue("color"));
            Assert.AreEqual(Formats.ErrorRed, forenameHelp.GetCssValue("color"));
            Assert.AreEqual("Forename is required", forenameHelp.Text);

            IWebElement email = _driver.FindElement(By.Id(LocatorsInContact.email));
            IWebElement emailLabel = _driver.FindElement(By.XPath(LocatorsInContact.emailLabel));
            IWebElement emailHelp = _driver.FindElement(By.XPath(LocatorsInContact.emailHelp));

            Assert.AreEqual(Formats.ErrorBorderRed, email.GetCssValue("border-color"));
            Assert.AreEqual(Formats.ErrorRed, email.GetCssValue("color"));
            Assert.AreEqual(Formats.ErrorRed, emailLabel.GetCssValue("color"));
            Assert.AreEqual(Formats.ErrorRed, emailHelp.GetCssValue("color"));
            Assert.AreEqual("Email is required", emailHelp.Text);

            IWebElement message = _driver.FindElement(By.Id(LocatorsInContact.message));
            IWebElement messageLabel = _driver.FindElement(By.XPath(LocatorsInContact.messageLabel));
            IWebElement messageHelp = _driver.FindElement(By.XPath(LocatorsInContact.messageHelp));

            Assert.AreEqual(Formats.ErrorBorderRed, message.GetCssValue("border-color"));
            Assert.AreEqual(Formats.ErrorRed, message.GetCssValue("color"));
            Assert.AreEqual(Formats.ErrorRed, messageLabel.GetCssValue("color"));
            Assert.AreEqual(Formats.ErrorRed, messageHelp.GetCssValue("color"));
            Assert.AreEqual("Message is required", messageHelp.Text);


        }
        [TestMethod]
        public void Contacts_PopulateManatoryFields_NoErrors()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            var SubmitButton = _driver.FindElement(By.ClassName("btn-contact"));
            IWebElement forename = _driver.FindElement(By.Id(LocatorsInContact.forename));
            IWebElement email = _driver.FindElement(By.Id(LocatorsInContact.email));
            IWebElement message = _driver.FindElement(By.Id(LocatorsInContact.message));

            forename.SendKeys("Test Name");
            email.SendKeys("Test@Address.com");
            message.SendKeys("Test Message");
            // Act
            SubmitButton.Click();
            //Assert
            IWebElement forenameLabel = _driver.FindElement(By.XPath(LocatorsInContact.forenameLabel));
            Assert.ThrowsException< OpenQA.Selenium.NoSuchElementException >(() => _driver.FindElement(By.XPath(LocatorsInContact.forenameHelp)));
            Assert.AreEqual(Formats.DefaultFieldColor, forename.GetCssValue("color"));
            Assert.AreEqual(Formats.DefaultLabelColor, forenameLabel.GetCssValue("color"));

            IWebElement emailLabel = _driver.FindElement(By.XPath(LocatorsInContact.emailLabel));
            Assert.ThrowsException<OpenQA.Selenium.NoSuchElementException>(() => _driver.FindElement(By.XPath(LocatorsInContact.emailHelp)));
            Assert.AreEqual(Formats.DefaultFieldColor, email.GetCssValue("color"));
            Assert.AreEqual(Formats.DefaultLabelColor, emailLabel.GetCssValue("color"));

            IWebElement messageLabel = _driver.FindElement(By.XPath(LocatorsInContact.messageLabel));
            Assert.ThrowsException<OpenQA.Selenium.NoSuchElementException>(() => _driver.FindElement(By.XPath(LocatorsInContact.messageHelp)));
            Assert.AreEqual(Formats.DefaultFieldColor, message.GetCssValue("color"));
            Assert.AreEqual(Formats.DefaultLabelColor, messageLabel.GetCssValue("color"));
        }
        [TestMethod]
        public void Contacts_PopulateManatoryFields_CheckPopup()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            var SubmitButton = _driver.FindElement(By.ClassName("btn-contact"));
            IWebElement forename = _driver.FindElement(By.Id(LocatorsInContact.forename));
            IWebElement email = _driver.FindElement(By.Id(LocatorsInContact.email));
            IWebElement message = _driver.FindElement(By.Id(LocatorsInContact.message));

            forename.SendKeys("Test Name");
            email.SendKeys("Test@Address.com");
            message.SendKeys("Test Message");
            // Act
            SubmitButton.Click();

            var simpleAlert = _driver.SwitchTo().Alert();
            //Assert
        }
        #endregion

        #region Missing Test
        [TestMethod]
        public void Contacts_EmailValidator_RangeOftestsRequired()
        {
            Assert.Inconclusive();
        }
    }
}
