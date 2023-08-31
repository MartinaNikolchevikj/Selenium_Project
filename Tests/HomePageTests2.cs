using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Final_Project.Pages;

namespace Selenium_Final_Project;

[TestFixture]
public class HomePageTests2
{

    IWebDriver driver;
    HomePage1 homePage1Object;
    TrendingStylesPage trendingStylesPageObject;
    WishlistPage wishlistPageObject;
    HomePage2 homePage2OPbject;

    [SetUp]
    public void Setup()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");
        driver.Manage().Window.Maximize();
        homePage1Object = new HomePage1(driver);
        trendingStylesPageObject = new TrendingStylesPage(driver);
        wishlistPageObject = new WishlistPage(driver);
        homePage2OPbject = new HomePage2(driver);
    }

    [Test]
    public void Tests()
    {
        homePage1Object.NavigateToTrendingStylesPage();
        homePage1Object.VerifyNavigatedToTrendingStylesPage();

        trendingStylesPageObject.ScrollIntoProductPurpleSolo2Wireless();
        trendingStylesPageObject.VerifyProductPurpleSolo2WirelessDisplayed();
        trendingStylesPageObject.AddProductPurpleSolo2WirelessToWishlist();

        wishlistPageObject.NavigateToWishlistPage();
        wishlistPageObject.VerifyNavigatedToWishlistPage();
        wishlistPageObject.VerifyProductPurpleSolo2WirelessInTheWishlist();

        homePage2OPbject.NavigateToHomePage();
        homePage2OPbject.VerifyNavigatedToHomePage();
        homePage2OPbject.ScrollIntoContactLink();
        homePage2OPbject.VerifyContactLinkDisplayed();
        homePage2OPbject.NavigateToContactPage();
        homePage2OPbject.VerifyNavigatedToContactPage();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}
