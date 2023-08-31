using System;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Selenium_Final_Project.Pages
{
    public class WishlistPage
    {
        IWebDriver driver;

        public WishlistPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToWishlistPage()
        {
            IWebElement openWishlist = driver.FindElement(By.CssSelector("i.ec.ec-favorites"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView()", openWishlist);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("i.ec.ec-favorites")));
            Thread.Sleep(2000);
            openWishlist.Click();
        }

        public void VerifyNavigatedToWishlistPage()
        {
            Assert.That(driver.Url, Is.EqualTo("https://electro.madrasthemes.com/wishlist/"));
        }
            
            public void VerifyProductPurpleSolo2WirelessInTheWishlist()
        {
            IWebElement productPurpleSolo2WirelessInTheWishlist = driver.FindElement(By.LinkText("Purple Solo 2 Wireless"));
            Assert.NotNull(productPurpleSolo2WirelessInTheWishlist, "Product not added to Wishlist");
        }

        
    }
}


