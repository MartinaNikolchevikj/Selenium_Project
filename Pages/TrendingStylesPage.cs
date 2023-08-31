
using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Final_Project.Pages
{
    public class TrendingStylesPage
    {
        IWebDriver driver;

        public TrendingStylesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ScrollIntoProductPurpleSolo2Wireless()
        {
            IWebElement purpleSolo2WirelessProduct = driver.FindElement(By.LinkText("Purple Solo 2 Wireless"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView()", purpleSolo2WirelessProduct);
        }

        public void VerifyProductPurpleSolo2WirelessDisplayed()
        {
            IWebElement purpleSolo2WirelessProduct = driver.FindElement(By.LinkText("Purple Solo 2 Wireless"));
            Assert.That(purpleSolo2WirelessProduct.Displayed);
        }

        public void AddProductPurpleSolo2WirelessToWishlist()
        {
            IWebElement purpleSolo2WirelessProduct = driver.FindElement(By.LinkText("Purple Solo 2 Wireless"));
            Thread.Sleep(2000);
            new Actions(driver).MoveToElement(purpleSolo2WirelessProduct).Perform();         

            IWebElement AddProductPurpleSolo2WirelessToWishlist = driver.FindElement(By.XPath("//a[@data-product-id = '2608']"));
            AddProductPurpleSolo2WirelessToWishlist.Click();
        }
    }
}

