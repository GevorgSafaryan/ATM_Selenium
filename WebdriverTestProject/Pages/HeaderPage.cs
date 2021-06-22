using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTestProject.Pages
{
    public class HeaderPage : BasePage
    {
        private string emailAddress = "//span[@class = 'ph-project__user-name svelte-a0l97g']";
        private string profileMenu = "//div[@class = 'ph-project ph-project__account svelte-a0l97g']";

        public bool VerifySuccessfulLogin(string login)
        {
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(emailAddress)));
            bool assertion =  Helpers.FindElementByXpath(Driver, emailAddress).Text.Contains(login);
            return assertion;
        }

        public void OpenProfileMenu()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(emailAddress))).Click();
        }
    }
}
