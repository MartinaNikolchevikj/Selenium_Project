using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Final_Project.Pages
{
    public class HomePage1
    {
        IWebDriver driver;

        public HomePage1(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public void NavigateToTrendingStylesPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Trending Styles']"))).Click();
        }
        public void VerifyNavigatedToTrendingStylesPage()
        {
            Assert.That(driver.Url, Is.EqualTo("https://electro.madrasthemes.com/home-v3-full-color-background/"));
        }
    }
}
