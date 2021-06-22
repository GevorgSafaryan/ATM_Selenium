using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTestProject.Pages
{
    public class HomePage : BasePage
    {
        private string loginField = "//input[@name = 'login']";
        private string enterPasswordButton = "//button[@data-testid= 'enter-password']";
        private string passwordField = "//input[@name= 'password']";
        private string enterButton = "//button[@data-testid= 'login-to-mail']";
        private string createAccountButton = "//a[@href = '//account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=52848']";

        public void Login(string login, string password)
        {
            Helpers.FindElementByXpath(Driver, loginField).SendKeys(login);
            Helpers.FindElementByXpath(Driver, enterPasswordButton).Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(passwordField))).SendKeys(password);
            Helpers.FindElementByXpath(Driver, enterButton).Click();
        }

        public bool VerifySuccessfullLogout()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(createAccountButton)));
            return Helpers.FindElementByXpath(Driver, createAccountButton).Displayed;
        }
    }
}
