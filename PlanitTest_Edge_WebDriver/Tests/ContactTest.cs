using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PlanitTest_Edge_WebDriver.Helpers;
using PlanitTest_Edge_WebDriver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PlanitTest_Edge_WebDriver
{
    [TestClass]
    public class ContactsTest : ContactPage
    {
        // Bug Test
        
        [TestMethod]
        public void Contacts_BorderColor_SetToRandomColor()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            var SubmitButton = _driver.FindElement(By.ClassName("btn-contact"));
            // Act
            List<string> actualBorders = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                SubmitButton.Click();
                // Assert
                IWebElement forename = _driver.FindElement(By.Id(LocatorsInContact.forename));
                // Forename.border appears to be set to some form of random color range
                // Raise Bug
                actualBorders.Add(forename.GetCssValue("border-color"));
            }
            string s1 = actualBorders[0];
            foreach (var item in actualBorders)
            {
                Debug.WriteLine(item);
                Assert.AreEqual(s1, item);
            }
        }

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

            // Forename.border appears to be set to some form of random color range
            // Raise Bug
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

            // act
            forename.SendKeys("Test Name");
            email.SendKeys("Test@Address.com");
            message.SendKeys("Test Message");

            // Assert
            IWebElement forenameLabel = _driver.FindElement(By.XPath(LocatorsInContact.forenameLabel));
            Assert.ThrowsException<OpenQA.Selenium.NoSuchElementException>(() => _driver.FindElement(By.XPath(LocatorsInContact.forenameHelp)));
            Assert.AreEqual(Formats.DefaultFieldColor, forename.GetCssValue("color"));
            Assert.AreEqual(Formats.DefaultLabelColor, forenameLabel.GetCssValue("color"));

            IWebElement emailLabel = _driver.FindElement(By.XPath(LocatorsInContact.emailLabel));
            IWebElement nextElementinEmailDiv = _driver.FindElement(By.XPath(LocatorsInContact.emailHelp));
            // Unlike other manditory fields this field has within its div other help details other than the dynamic error label.
            // validate that the next label is standard help text not error text.
            Assert.AreEqual("Your email address will only be used in reply to this message.", nextElementinEmailDiv.Text);
            Assert.AreEqual(Formats.DefaultFieldColor, email.GetCssValue("color"));
            Assert.AreEqual(Formats.DefaultLabelColor, emailLabel.GetCssValue("color"));

            IWebElement messageLabel = _driver.FindElement(By.XPath(LocatorsInContact.messageLabel));
            Assert.ThrowsException<OpenQA.Selenium.NoSuchElementException>(() => _driver.FindElement(By.XPath(LocatorsInContact.messageHelp)));
            Assert.AreEqual(Formats.DefaultFieldColor, message.GetCssValue("color"));
            Assert.AreEqual(Formats.DefaultLabelColor, messageLabel.GetCssValue("color"));
        }
        #endregion
        #region Test Case 2
        [TestMethod]
        public void Contacts_PopulateManatoryFields_CheckPopup_once()
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
            var popup = _driver.FindElement(By.XPath(LocatorsInContact.Popup));
            Assert.IsTrue(popup.Displayed);
            while (popup.Displayed)
            {
            }
            Assert.IsFalse(popup.Displayed);
            var submitedmessage = _driver.FindElement(By.XPath(LocatorsInContact.SubmittedMessage));
            Assert.AreEqual("Thanks Test Name, we appreciate your feedback.", submitedmessage.Text);
        }
        [TestMethod]
        public void Contacts_PopulateManatoryFields_CheckPopup_FiveTimes()
        {
            // Arrange
            _driver.Url = Urls.Contact;
            // Act
            int loopCount = 0;
            for (int i = 1; i <= 5; i++)
            {
                var SubmitButton = _driver.FindElement(By.ClassName("btn-contact"));
                IWebElement forename = _driver.FindElement(By.Id(LocatorsInContact.forename));
                IWebElement email = _driver.FindElement(By.Id(LocatorsInContact.email));
                IWebElement message = _driver.FindElement(By.Id(LocatorsInContact.message));

                forename.SendKeys("Test Name");
                email.SendKeys("Test@Address.com");
                message.SendKeys("Test Message");
                SubmitButton.Click();
                var popup = _driver.FindElement(By.XPath(LocatorsInContact.Popup));
                while (popup.Displayed) { }
                var backButton = _driver.FindElement(By.XPath(LocatorsInContact.BackButton));
                backButton.Click();
                loopCount++;
            }
            //Assert
            Assert.AreEqual(5, loopCount);
        }
        #endregion

        #region Missing Test
        [TestMethod]
        public void Contacts_EmailValidator_RangeOftestsRequired()
        {
            Assert.Inconclusive();
        }
        #endregion

    }
}
