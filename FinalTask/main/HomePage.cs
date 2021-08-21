using System;
using OpenQA.Selenium;


namespace FinalTask
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        private readonly static By TSHIRTSBUTTON = By.XPath("//*[@id='block_top_menu']/ul/li[3]/a");
        private readonly static By DRESSESSBUTTON = By.XPath("//*[@id='block_top_menu']/ul/li[2]/a");


        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public TShirtsPage GoToTShirts()
        {
            _driver.FindElement(TSHIRTSBUTTON).Click();

            return new TShirtsPage(_driver);
        }

        public DressesPage GoToDresses()
        {
            _driver.FindElement(DRESSESSBUTTON).Click();

            return new DressesPage(_driver);
        }
    }
}
