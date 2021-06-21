using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;

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
            //Wait.Until(WaitConditions.IsElementDisplayed(Helpers.FindElementByXpath(Driver, passwordField)));
            Helpers.FindElementByXpath(Driver, passwordField).SendKeys(password);
            Helpers.FindElementByXpath(Driver, enterButton).Click();
        }

        public bool VerifySuccessfullLogout()
        {
            return Helpers.FindElementByXpath(Driver, createAccountButton).Displayed;
        }
    }
}
