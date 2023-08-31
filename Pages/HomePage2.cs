using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Final_Project.Pages
{
    public class HomePage2
    {
        IWebDriver driver;

        public HomePage2(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToHomePage()
        {
            IWebElement home = driver.FindElement(By.XPath("//a[@class = 'header-logo-link']"));
            home.Click();
        }

        public void VerifyNavigatedToHomePage()
        {
            Assert.That(driver.Url, Is.EqualTo("https://electro.madrasthemes.com/"));
        }

        public void ScrollIntoContactLink()
        {
            IWebElement contactLink = driver.FindElement(By.XPath("//div[@class = 'copyright-bar']"));
           
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView()", contactLink);
            Thread.Sleep(2000);
        }

        public void VerifyContactLinkDisplayed()
        {
            IWebElement contactLink = driver.FindElement(By.LinkText("Contact"));
            Assert.IsTrue(contactLink.Displayed);
        }

        public void NavigateToContactPage()
        {           
            IWebElement navigateToContactPage = driver.FindElement(By.LinkText("Contact"));
            navigateToContactPage.Click();
        }

        public void VerifyNavigatedToContactPage()
        {
            Assert.That(driver.Url, Is.EqualTo("https://electro.madrasthemes.com/contact-v1/"));
        }
    }
}