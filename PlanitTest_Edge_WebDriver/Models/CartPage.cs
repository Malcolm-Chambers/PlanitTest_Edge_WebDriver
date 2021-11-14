using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using PlanitTest_Edge_WebDriver.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace PlanitTest_Edge_WebDriver.Models
{
    public class CartPage : BaseTest
    {
        public Dictionary<string, Tuple<string, IWebElement>> CartList;

        public static Dictionary<string, Tuple<string, IWebElement, string,IWebElement>> LoadProductList(EdgeDriver _driver)
        {
            var result = new Dictionary<string, Tuple<string, IWebElement, string,IWebElement>>();
            var cartTable = _driver.FindElement(By.ClassName("table"));
            var cartList = cartTable.FindElement(By.TagName("tbody"));
            var products = cartList.FindElements(By.TagName("tr"));
            List<IWebElement> rowElements = new List<IWebElement>();

            for (int i = 0; i < products.Count; i++)
            {
                    IWebElement row = products[i];
                    var rowDetails = row.FindElements(By.TagName("td"));
                    result.Add(rowDetails[0].Text, Tuple.Create(rowDetails[1].Text, rowDetails[2], rowDetails[3].Text,rowDetails[4]));
            }
            return result;
        }
        public static string FetchGrandTotalPrice(EdgeDriver _driver)
        {
            var cartTable = _driver.FindElement(By.ClassName("table"));
            var cartFooter = cartTable.FindElement(By.TagName("tfoot"));
            var products = cartFooter.FindElements(By.TagName("tr"));
            IWebElement row = products[0];
            var rowDetail = row.FindElement(By.TagName("td"));
            return rowDetail.Text;
        }
        public static Tuple<IWebElement,IWebElement> FetchTableButtons(EdgeDriver _driver)
        {
            var cartTable = _driver.FindElement(By.ClassName("table"));
            var cartFooter = cartTable.FindElement(By.TagName("tfoot"));
            var products = cartFooter.FindElements(By.TagName("tr"));
            IWebElement row = products[1];
            var rowDetails = row.FindElements(By.TagName("a"));
            return Tuple.Create(rowDetails[0],rowDetails[1]);
        }
    }
}
