using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTask
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;

        private readonly static By ADDTOWISHLISTBUTTON = By.Id("wishlist_button");
        private readonly static By HOMEBUTTON = By.CssSelector("[title='Return to Home']");
        private readonly static By ACCOUNTBUTTON = By.ClassName("account");
        private readonly static By ADDTOCARTBUTTON = By.CssSelector("#add_to_cart > button");
        private readonly static By QUANTITYINPUT = By.Id("quantity_wanted");
        private readonly static By SHOPPINGCARTBUTTON = By.CssSelector("[title='View my shopping cart']");
        private readonly static By CONTINUEBUTTON = By.ClassName("continue");




        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddToCart()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.FindElement(QUANTITYINPUT).SendKeys(Keys.Backspace);
            _driver.FindElement(QUANTITYINPUT).SendKeys("3");
            _driver.FindElement(ADDTOCARTBUTTON).Click();
            var wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.FindElement(CONTINUEBUTTON).Click();
        }

        public void AddToWishlist()
        {
            _driver.FindElement(ADDTOWISHLISTBUTTON).Click();
        }

        public HomePage GoToHome()
        {
            _driver.FindElement(HOMEBUTTON).Click();

            return new HomePage(_driver);
        }

        public AccountPage GoToAccount()
        {
            _driver.FindElement(ACCOUNTBUTTON).Click();

            return new AccountPage(_driver);
        }

        public ShoppingCartPage GoToShoppingCart()
        {
            _driver.FindElement(SHOPPINGCARTBUTTON).Click();

            return new ShoppingCartPage(_driver);
        }
    }
}
