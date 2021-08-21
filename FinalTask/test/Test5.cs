using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Allure.Commons;
using Allure.NUnit.Attributes;
using System;

namespace FinalTask
{
    public class Test5 : AllureReport
    {
        private readonly IWebDriver _driver = Test12.switchWebDriver(0);

        private LoginPage _loginPage;
        private AccountPage _accountPage;
        private HomePage _homePage;
        private TShirtsPage _tshirtsPage;
        private ShoppingCartPage _shoppingCartPage;
        private ProductPage _productPage;

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureSubSuite("AddToCartTest")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Normal)]
        [AllureLink("AP-5")]
        [AllureTest("Verify the ability to add to cart")]
        [AllureOwner("ArtemOpanasenko")]
        public void AP5()
        {
            _loginPage = new LoginPage(_driver);
            _loginPage.Navigate(Test12.LOGINPAGEURL);
            _accountPage = _loginPage.Login(Test12.EMAILFORLOGIN, Test12.PASSWORD);

            _homePage = _accountPage.GoToHome();
            _tshirtsPage = _homePage.GoToTShirts();
            _productPage = _tshirtsPage.GoToProduct();
            _productPage.AddToCart();

            _shoppingCartPage = _productPage.GoToShoppingCart();


            Assert.That(_shoppingCartPage.CheckTotal(), "Total sum is wrong");

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
