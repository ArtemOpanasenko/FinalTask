using System;
using OpenQA.Selenium;

namespace FinalTask
{
    public class TShirtsPage
    {
        private readonly IWebDriver _driver;

        private readonly static By PRODUCTELEMENT = By.CssSelector("li.ajax_block_product");
        private readonly static By HOMEBUTTON = By.CssSelector("[title='Return to Home']");
        private readonly static By ACCOUNTBUTTON = By.ClassName("account");
        private readonly static By ADDTOCARTBUTTON = By.CssSelector("#add_to_cart > button");



        public TShirtsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public ProductPage GoToProduct()
        {
            _driver.FindElement(PRODUCTELEMENT).Click();

            return new ProductPage(_driver);
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
    }
}
