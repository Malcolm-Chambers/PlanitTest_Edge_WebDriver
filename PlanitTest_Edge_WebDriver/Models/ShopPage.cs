using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using PlanitTest_Edge_WebDriver.Helpers;

namespace PlanitTest_Edge_WebDriver.Models
{
    public class ShopPage : BaseTest
    {
        
        public Dictionary<string, Tuple<string,IWebElement>> ProductList;

        protected static Dictionary<string, Tuple<string, IWebElement>> LoadProductList( EdgeDriver _driver)
        {
            var result = new Dictionary<string, Tuple<string, IWebElement>>();
            var productList = _driver.FindElement(By.ClassName("products"));
            var products = productList.FindElements(By.ClassName("product"));
            foreach (var product in products)
            {
                string text = product.Text; 
                var productName = text.Split("\r")[0];
                string price = text.Split("\n")[1].Split(' ')[0];
                var buyButton = product.FindElement(By.ClassName("btn"));
                result.Add(productName, Tuple.Create(price, buyButton));
            }
            return result;
        }
    }
}
