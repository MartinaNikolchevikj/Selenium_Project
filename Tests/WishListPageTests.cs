using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Final_Project.Pages;

namespace Selenium_Final_Project;

[TestFixture]
public class WishlistPageTests
{
    IWebDriver driver;
    HomePage1 homePageObject;
    TrendingStylesPage trendingStylesPageObject;
    WishlistPage wishlistPageObject;

    [SetUp]
    public void Setup()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");
        driver.Manage().Window.Maximize();
        homePageObject = new HomePage1(driver);
        trendingStylesPageObject = new TrendingStylesPage(driver);
        wishlistPageObject = new WishlistPage(driver);
    }

    [Test]
    public void WishlistsPageTests()
    {
        homePageObject.NavigateToTrendingStylesPage();
        homePageObject.VerifyNavigatedToTrendingStylesPage();

        trendingStylesPageObject.ScrollIntoProductPurpleSolo2Wireless();
        trendingStylesPageObject.VerifyProductPurpleSolo2WirelessDisplayed();
        trendingStylesPageObject.AddProductPurpleSolo2WirelessToWishlist();

        wishlistPageObject.NavigateToWishlistPage();
        wishlistPageObject.VerifyNavigatedToWishlistPage();
        wishlistPageObject.VerifyProductPurpleSolo2WirelessInTheWishlist();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}
