using System;
using OpenQA.Selenium;


namespace FinalTask
{
    public class AccountPage
    {
        private readonly IWebDriver _driver;

        private readonly By SIGNOUTBUTTON = By.ClassName("logout");
        private readonly By WISHLISTBUTTON = By.ClassName("lnk_wishlist");
        private readonly static By HOMEBUTTON = By.CssSelector("[title='Return to Home']");


        public AccountPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CheckSignIn()
        {
            return _driver.FindElement(SIGNOUTBUTTON).Displayed;
        }

        public LoginPage SignOut()
        {
            _driver.FindElement(SIGNOUTBUTTON).Click();

            return new LoginPage(_driver);
        }

        public WishlistPage GoToWishlist()
        {
            _driver.FindElement(WISHLISTBUTTON).Click();

            return new WishlistPage(_driver);
        }

        public HomePage GoToHome()
        {
            _driver.FindElement(HOMEBUTTON).Click();

            return new HomePage(_driver);
        }
    }
}
