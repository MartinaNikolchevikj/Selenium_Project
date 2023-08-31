using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Final_Project.Pages;

namespace Selenium_Final_Project;

[TestFixture]
public class HomePageTests1
{
    IWebDriver driver;
    HomePage1 homePage1Object;

    [SetUp]
    public void Setup()
    {
        
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");
        driver.Manage().Window.Maximize();
        homePage1Object = new HomePage1(driver);
    }

    [Test]
    public void Tests()
    {
        homePage1Object.NavigateToTrendingStylesPage();
        homePage1Object.VerifyNavigatedToTrendingStylesPage();
    }
 
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}
