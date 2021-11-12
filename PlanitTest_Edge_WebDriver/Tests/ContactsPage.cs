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

        [TestMethod]
        public void AccessContacts_PressSubmit_MissingDefaults()
        {
            // Replace with your own test logic
            _driver.Url = Urls.Contact;
            var SubmitButton =  _driver.FindElement(By.ClassName("btn-contact"));
            SubmitButton.Click();

            IWebElement forename = _driver.FindElement(By.Id("forename"));
            IWebElement surname = _driver.FindElement(By.Id("surname"));
            IWebElement email = _driver.FindElement(By.Id("email"));
            IWebElement telephone = _driver.FindElement(By.Id("telephone"));
            IWebElement message = _driver.FindElement(By.Id("message"));

            Assert.IsNotNull(forename);
            Assert.IsNotNull(surname);
            Assert.IsNotNull(email);
            Assert.IsNotNull(telephone);
            Assert.IsNotNull(forename);
        }
    }
}
