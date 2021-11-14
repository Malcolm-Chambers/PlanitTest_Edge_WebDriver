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
    public class CartTests : ShopPage
    {
        #region Test case 3
        [TestMethod]
        public void BuyStuff_CheckDetailsOfCart()
        {
            // arrange
            _driver.Url = Urls.Shop;
            ProductList = LoadProductList(_driver);
            ProductList["Funny Cow"].Item2.Click();
            ProductList["Funny Cow"].Item2.Click();
            ProductList["Fluffy Bunny"].Item2.Click();
            // act

            _driver.FindElement(By.XPath(LocatorsInShop.CartButton)).Click();
            IWebElement msg;
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            msg = wait.Until(_driver => _driver.FindElement(By.XPath("/html/body/div[2]/div/p")));

            Dictionary<string, Tuple<string, IWebElement, string, IWebElement>> productsInCart = CartPage.LoadProductList(_driver);
            // assert

            Assert.AreEqual("There are 3 items in your cart, you can Checkout or carry on Shopping.", msg.Text);
            Assert.AreEqual("$10.99", productsInCart["Funny Cow"].Item1);
            Assert.AreEqual("$9.99", productsInCart["Fluffy Bunny"].Item1);
            Assert.AreEqual(2, productsInCart.Count, "Verify only two types items in cart");
        }
        #endregion
        #region Test case 4
        [TestMethod]
        public void BuyStuff_CheckTotalsOfCart()
        {
            // arrange
            _driver.Url = Urls.Shop;
            ProductList = LoadProductList(_driver);
            ProductList["Stuffed Frog"].Item2.Click();
            ProductList["Valentine Bear"].Item2.Click();
            ProductList["Fluffy Bunny"].Item2.Click();
            ProductList["Stuffed Frog"].Item2.Click();
            ProductList["Valentine Bear"].Item2.Click();
            ProductList["Fluffy Bunny"].Item2.Click();
            ProductList["Valentine Bear"].Item2.Click();
            ProductList["Fluffy Bunny"].Item2.Click();
            ProductList["Fluffy Bunny"].Item2.Click();
            ProductList["Fluffy Bunny"].Item2.Click();
            // act

            _driver.FindElement(By.XPath(LocatorsInShop.CartButton)).Click();
            IWebElement msg;
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            msg = wait.Until(_driver => _driver.FindElement(By.XPath("/html/body/div[2]/div/p")));

            // assert
            Dictionary<string, Tuple<string, IWebElement, string, IWebElement>> productsInCart = CartPage.LoadProductList(_driver);
            string grandTotal = CartPage.FetchGrandTotalPrice(_driver);

            Assert.AreEqual("There are 10 items in your cart, you can Checkout or carry on Shopping.", msg.Text);
            Assert.AreEqual("$10.99", productsInCart["Stuffed Frog"].Item1);
            Assert.AreEqual("$21.98", productsInCart["Stuffed Frog"].Item3);

            Assert.AreEqual("$14.99", productsInCart["Valentine Bear"].Item1);
            Assert.AreEqual("$44.97", productsInCart["Valentine Bear"].Item3);

            Assert.AreEqual("$9.99", productsInCart["Fluffy Bunny"].Item1);
            Assert.AreEqual("$49.95", productsInCart["Fluffy Bunny"].Item3);

            Assert.AreEqual("Total: 116.90", grandTotal);
            Assert.AreEqual(3, productsInCart.Count, "Verify only two types items in cart");
        }

        #endregion
        #region Missing Tests
        [TestMethod]
        public void RemoveAnItemFromCart_OnlyItemInCart()
        {
            Assert.Inconclusive();
        }
        public void RemoveAnItemFromCart_MultipleItemsInCart()
        {
            Assert.Inconclusive();
        }
        public void EmptyCart()
        {
            Assert.Inconclusive();
        }
        public void CheckOutFromCart_ViaHyperLink()
        {
            Assert.Inconclusive();
        }
        public void CheckOutFromCart_ViaTableButton()
        {
            Assert.Inconclusive();
        }
        public void ReturnToShop_ViaHyperLink()
        {
            Assert.Inconclusive();
        }
        public void ReturnToShop_ViaMenu()
        {
            Assert.Inconclusive();
        }


        #endregion
    }
}
