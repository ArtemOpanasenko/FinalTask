using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Allure.Commons;
using Allure.NUnit.Attributes;
using System;

namespace FinalTask
{
    public class Test4 : AllureReport
    {
        private readonly static string WISHLISTNAME = "mywishlist";

        private readonly IWebDriver _driver = Test12.switchWebDriver(0);

        private LoginPage _loginPage;
        private AccountPage _accountPage;
        private WishlistPage _wishlistPage;
        private HomePage _homePage;
        private TShirtsPage _tshirtsPage;
        private ProductPage _productPage;


        [SetUp]
        public void Setup()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureSubSuite("AddToWishlistTest")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Normal)]
        [AllureLink("AP-4")]
        [AllureTest("Verify the ability to add to your Wishlist")]
        [AllureOwner("ArtemOpanasenko")]
        public void AP4()
        {
            _loginPage = new LoginPage(_driver);
            _loginPage.Navigate(Test12.LOGINPAGEURL);
            _accountPage = _loginPage.Login(Test12.EMAILFORLOGIN, Test12.PASSWORD);

            _wishlistPage = _accountPage.GoToWishlist();
            _wishlistPage.DeleteWishList();
            _wishlistPage.CreateNewWishlist(WISHLISTNAME);

            _homePage = _wishlistPage.GoToHome();
            _tshirtsPage = _homePage.GoToTShirts();
            _productPage = _tshirtsPage.GoToProduct();
            _productPage.AddToWishlist();
            _accountPage = _productPage.GoToAccount();
            _wishlistPage = _accountPage.GoToWishlist();

            Assert.That(!_wishlistPage.IsWishlistEmpty(), "There is nothing in your wishlist");
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.FailCount != 0)
            {
                var screen = ((ITakesScreenshot)_driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("Failed test", "image/png", screen);
            }
            _driver.Quit();
        }
    }
}
