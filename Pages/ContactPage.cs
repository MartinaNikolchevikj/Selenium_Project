using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Final_Project.Pages
{
    public class ContactPage
    {
        IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ScrollToLeaveUsAMessageWindow()
        {
            IWebElement leaveUsAMessage = driver.FindElement(By.XPath("//div[@id = 'wpforms-5460']"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView()", leaveUsAMessage);
        }

        public void VerifyLeaveUsAMessageWindowDisplayed()
           
        {
            IWebElement leaveUsAMessage = driver.FindElement(By.XPath("//div[@id = 'wpforms-5460']"));
            Assert.IsTrue(leaveUsAMessage.Displayed);
        }

        //GenerateRandomMail
        public void Main(string[] args)
        {
            string randomEmail = GenerateRandomEmail();
            Console.WriteLine(randomEmail);
        }

        static string GenerateRandomEmail()
        {
            string[] domains = { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com", "example.com" };
            string[] prefixes = { "user", "name", "dammy", "test", "random" };

            Random random = new Random();
            string randomPrefix = prefixes[random.Next(prefixes.Length)];
            string randomDomain = domains[random.Next(domains.Length)];

            return $"{randomPrefix}@{randomDomain}";
        }
        //

        public void FillTheRequiredFields()
        {
            string name = "Name";
            string surname = "Surname";
            string email = GenerateRandomEmail();
            string text = "That's All Folks!";

            IWebElement textArea = driver.FindElement(By.XPath("//textarea[@id = 'wpforms-5460-field_2']"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView()", textArea);

            IWebElement nameField = driver.FindElement(By.XPath("//input[@placeholder = 'First Name']"));
            nameField.Clear();
            nameField.SendKeys(name);

            IWebElement surnameField = driver.FindElement(By.XPath("//input[@placeholder = 'Last Name']"));
            surnameField.Clear();
            surnameField.SendKeys(surname);

            IWebElement emailField = driver.FindElement(By.XPath("//input[@placeholder = 'Enter your email address']"));
            emailField.Clear();
            emailField.SendKeys(email);
            
            textArea.Clear();        
            textArea.SendKeys(text);
        }

        public void SendMessage()
        {
            IWebElement sendMessageButton = driver.FindElement(By.XPath("//button[@data-submit-text = 'Send Message']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click()", sendMessageButton);
        }

        public void VerifyMessageSent()
        {
            IWebElement messageSuccessfullySent = driver.FindElement(By.CssSelector("div.wpforms-confirmation-container-full.wpforms-confirmation-scroll"));
            Assert.That(messageSuccessfullySent.Displayed);
        }
    }
}


