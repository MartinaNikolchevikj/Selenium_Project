using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Final_Project.Pages;

namespace Selenium_Final_Project;

[TestFixture]
public class TrendingStylesPageTests
{
    IWebDriver driver;
    HomePage1 homePageObject;
    TrendingStylesPage trendingStylesPageObject;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");
        driver.Manage().Window.Maximize();
        homePageObject = new HomePage1(driver);
        trendingStylesPageObject = new TrendingStylesPage(driver);
    }

    [Test]
    public void TrendingPageTests()
    {
        homePageObject.NavigateToTrendingStylesPage();
        homePageObject.VerifyNavigatedToTrendingStylesPage();

        trendingStylesPageObject.ScrollIntoProductPurpleSolo2Wireless();
        trendingStylesPageObject.VerifyProductPurpleSolo2WirelessDisplayed();
        trendingStylesPageObject.AddProductPurpleSolo2WirelessToWishlist();
    }
  
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}
