using System;
using OpenQA.Selenium;

namespace FinalTask
{
    public class DressesPage
    {
        private readonly IWebDriver _driver;

        private readonly static By PRODUCTELEMENT = By.CssSelector("li.ajax_block_product");
        private readonly static By ADDTOWISHLISTBUTTON = By.Id("wishlist_button");
        private readonly static By HOMEBUTTON = By.CssSelector("[title='Return to Home']");
        private readonly static By ACCOUNTBUTTON = By.ClassName("account");
        private readonly static By PRODUCT1 = By.XPath("//*[@id='center_column']/ul/li[1]/div/div[1]");
        private readonly static By PRODUCT2 = By.XPath("//*[@id='center_column']/ul/li[2]/div/div[1]");
        private readonly static By PRODUCT3 = By.XPath("//*[@id='center_column']/ul/li[3]");
        private readonly static By ADDTOCARTBUTTON = By.CssSelector("#add_to_cart > button");
        private readonly static By CONTINUEBUTTON = By.ClassName("continue");
        private readonly static By DRESSESBUTTON = By.XPath("//div[@id='columns']//a[@title='Dresses']");
        private readonly static By CLOSEWINDOWBUTTON = By.CssSelector("[title='Close window']");
        private readonly static By SHOPPINGCARTBUTTON = By.CssSelector("[title='View my shopping cart']");



        public DressesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddToCart()
        {
            _driver.FindElement(PRODUCT1).Click();
            _driver.FindElement(ADDTOCARTBUTTON).Click();
            _driver.FindElement(CONTINUEBUTTON).Click();
            _driver.FindElement(DRESSESBUTTON).Click();

            _driver.FindElement(PRODUCT2).Click();
            _driver.FindElement(ADDTOCARTBUTTON).Click();
            _driver.FindElement(CONTINUEBUTTON).Click();
            _driver.FindElement(DRESSESBUTTON).Click();

            _driver.FindElement(PRODUCT3).Click();
            _driver.FindElement(ADDTOCARTBUTTON).Click();
            _driver.FindElement(CONTINUEBUTTON).Click();
            _driver.FindElement(DRESSESBUTTON).Click();
        }

        public ProductPage GoToProduct()
        {
            _driver.FindElement(PRODUCT2).Click();

            return new ProductPage(_driver);
        }

        public void AddToWishlist()
        {
            _driver.FindElement(PRODUCTELEMENT).Click();
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
