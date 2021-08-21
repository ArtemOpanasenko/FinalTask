using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTask
{
    public class CreateAccountPage
    {
        private readonly IWebDriver _driver;

        private readonly By FIRSTNAMEINPUT = By.Id("customer_firstname");
        private readonly By LASTNAMEINPUT = By.Id("customer_lastname");
        private readonly By PASSWORDINPUT = By.Id("passwd");
        private readonly By ADDRESSINOUT = By.Id("address1");
        private readonly By CITYINPUT = By.Id("city");
        private readonly By STATESELECT = By.Id("id_state");
        private readonly By POSTCODEINPUT = By.Id("postcode");
        private readonly By MOBILEPHONEINPUT = By.Id("phone_mobile");
        private readonly By ALIASINPUT = By.Id("alias");
        private readonly By REGISTERBUTTON = By.Id("submitAccount");
            




        public CreateAccountPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public AccountPage CreateAccount(string firstName, string lastName, string password, string address,
            string city, string state, string postcode, string mobilePhone)
        {
            _driver.FindElement(FIRSTNAMEINPUT).SendKeys(firstName);
            _driver.FindElement(LASTNAMEINPUT).SendKeys(lastName);
            _driver.FindElement(PASSWORDINPUT).SendKeys(password);
            _driver.FindElement(ADDRESSINOUT).SendKeys(address);
            _driver.FindElement(CITYINPUT).SendKeys(city);
            SelectElement stateSelect = new SelectElement(_driver.FindElement(STATESELECT));
            stateSelect.SelectByText(state);
            _driver.FindElement(POSTCODEINPUT).SendKeys(postcode);
            _driver.FindElement(MOBILEPHONEINPUT).SendKeys(mobilePhone);
            _driver.FindElement(ALIASINPUT).SendKeys(address);
            _driver.FindElement(REGISTERBUTTON).Click();

            return new AccountPage(_driver);
        }
    }
}
