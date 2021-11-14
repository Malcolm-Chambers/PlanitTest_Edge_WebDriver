using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlanitTest_Edge_WebDriver.Helpers;
using PlanitTest_Edge_WebDriver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanitTest_Edge_WebDriver
{
    [TestClass]
    public class ShopTests : ShopPage
    {
        #region Test case 3
        [TestMethod]
        public void BuyStuff_CheckCartButtonShowsThreeItemsInCart()
        {
            // arrange
            _driver.Url = Urls.Shop;
            ProductList = LoadProductList(_driver);
            ProductList["Funny Cow"].Item2.Click();
            ProductList["Funny Cow"].Item2.Click();
            ProductList["Fluffy Bunny"].Item2.Click();
            // act
            string actual = _driver.FindElement(By.XPath(LocatorsInShop.CartButton)).Text;
            // assert
            Assert.AreEqual("Cart (3)", actual);
        }
        #endregion
    }
}