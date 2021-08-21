using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Allure.Commons;
using Allure.NUnit.Attributes;
using System;

namespace FinalTask
{
    public class Test12 : AllureReport
    {
        public const string LOGINPAGEURL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        public const string EMAILFORLOGIN = "artemOpanasenk@mail.ru";
        public const string PASSWORD = "qwerty";

        private static readonly string EMAILFORREGISTRATION = "artemOpanasenk@mail.ru";
        private static readonly string FIRSTNAME = "artem";
        private static readonly string LASTNAME = "opanasenko";
        private static readonly string ADDRESS = "gurskogo 44";
        private static readonly string CITY = "minsk";
        private static readonly string STATE = "New York";
        private static readonly string POSTCODE = "22007";
        private static readonly string MOBILEPHONE = "+375333133818";


        private readonly IWebDriver _driver = switchWebDriver(0);

        private LoginPage _loginPage;
        private CreateAccountPage _createAccountPage;
        private AccountPage _accountPage;



        [OneTimeSetUp]
        public void Setup()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureSubSuite("CreateAccountTest")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Normal)]
        [AllureLink("AP-1")]
        [AllureTest("Verify the ability to create an account")]
        [AllureOwner("ArtemOpanasenko")]
        public void AP1()
        {
            _loginPage = new LoginPage(_driver);
            _loginPage.Navigate(LOGINPAGEURL);
            _createAccountPage = _loginPage.GoToCreating(EMAILFORREGISTRATION);
            _accountPage = _createAccountPage.CreateAccount(FIRSTNAME, LASTNAME, PASSWORD, ADDRESS, CITY, STATE, POSTCODE, MOBILEPHONE);

            Assert.That(_accountPage.CheckSignIn(), "Account was not created");
        }

        [Test]
        [AllureSubSuite("LoginAccountTest")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Normal)]
        [AllureLink("AP-2")]
        [AllureTest("Verify the ability to login in account")]
        [AllureOwner("ArtemOpanasenko")]
        public void AP2()
        {
            _loginPage = _accountPage.SignOut();
            _accountPage = _loginPage.Login(EMAILFORLOGIN, PASSWORD);

            Assert.That(_accountPage.CheckSignIn(), "Account was not created");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.FailCount != 0)
            {
                var screen = ((ITakesScreenshot)_driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("Failed test", "image/png", screen);
            }
            _driver.Quit();
        }

        public static IWebDriver switchWebDriver(int switchNumber)
        {
            var _sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var _sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
            var _caps = new DesiredCapabilities();
            switch (switchNumber)
            {
                case 0:
                    return new ChromeDriver();
                case 1:
                    return new RemoteWebDriver(new Uri("http://10.10.103.32:4444/wd/hub"), new ChromeOptions());
                case 2:
                    _caps.SetCapability("browserName", "Firefox");
                    _caps.SetCapability("platform", "Windows 10");
                    _caps.SetCapability("version", "latest");
                    _caps.SetCapability("username", _sauceUserName);
                    _caps.SetCapability("accessKey", _sauceAccessKey);
                    _caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

                    return new RemoteWebDriver(new Uri("https://oauth-artsem.opanasenko-4d64e:1ae80361-ceb3-45b6-bf81-33d297bffaa2@ondemand.eu-central-1.saucelabs.com:443/wd/hub"),
_caps, TimeSpan.FromSeconds(60));
                default:
                    Console.WriteLine("Wrong number of driver!");
                    return new ChromeDriver();
            }
        }
    }
}