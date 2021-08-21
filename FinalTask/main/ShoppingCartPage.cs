using System;
using OpenQA.Selenium;

namespace FinalTask
{
    public class ShoppingCartPage
    {
        private readonly static By TOTALPRICE = By.Id("total_price");

        private readonly IWebDriver _driver;

        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CheckTotal()
        {
            return _driver.FindElement(TOTALPRICE).Text == "$51.53";
        }
    }
}
