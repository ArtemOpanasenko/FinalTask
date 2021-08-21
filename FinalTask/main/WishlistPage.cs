using System;
using OpenQA.Selenium;

namespace FinalTask
{
    public class WishlistPage
    {
        private readonly IWebDriver _driver;

        private readonly static By WISHLISTTABLE = By.Id("block-history");
        private readonly static By HOMEBUTTON = By.CssSelector("[title='Return to Home']");
        private readonly static By ICONREMOVEBUTTON = By.ClassName("icon-remove");
        private readonly static By WISHLISTNAMEINPUT = By.Id("name");
        private readonly static By SUBMITWISHLISTBUTTON = By.Id("submitWishlist");
        private readonly static By NUMBEROFPRODUCTSINWISHLIST = By.ClassName("bold");




        public WishlistPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsWishlistExist()
        {
            try
            {
                _driver.FindElement(WISHLISTTABLE);
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            return true;
        }

        public void DeleteWishList()
        {
            _driver.FindElement(ICONREMOVEBUTTON).Click();
            _driver.SwitchTo().Alert().Accept();
            _driver.FindElement(ICONREMOVEBUTTON).Click();
            _driver.SwitchTo().Alert().Accept();
        }

        public void CreateNewWishlist(string wishlistName)
        {
            _driver.FindElement(WISHLISTNAMEINPUT).SendKeys(wishlistName);
            _driver.FindElement(SUBMITWISHLISTBUTTON).Click();
        }

        public bool IsWishlistEmpty()
        {
            return _driver.FindElement(NUMBEROFPRODUCTSINWISHLIST).Text == "0";
        }

        public HomePage GoToHome()
        {
            _driver.FindElement(HOMEBUTTON).Click();

            return new HomePage(_driver);
        }
    }
}
