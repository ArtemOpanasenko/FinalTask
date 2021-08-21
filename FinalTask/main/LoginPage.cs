using System;
using OpenQA.Selenium;

namespace FinalTask
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        private readonly By EMAILCREATEINPUT = By.Id("email_create");
        private readonly By CREATEANACCOUNTBUTTON = By.Id("SubmitCreate");

        private readonly By EMAILINPUT = By.Id("email");
        private readonly By PASSWORDINPUT = By.Id("passwd");
        private readonly By SIGNINBUTTON = By.Id("SubmitLogin");


        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public CreateAccountPage GoToCreating(string email)
        {
            _driver.FindElement(EMAILCREATEINPUT).SendKeys(email);
            _driver.FindElement(CREATEANACCOUNTBUTTON).Click();

            return new CreateAccountPage(_driver);
        }

        public AccountPage Login(string email, string password)
        {
            _driver.FindElement(EMAILINPUT).SendKeys(email);
            _driver.FindElement(PASSWORDINPUT).SendKeys(password);
            _driver.FindElement(SIGNINBUTTON).Click();

            return new AccountPage(_driver);
        }
    }
}
