using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;

namespace WebdriverTestProject.Pages
{
    public class ProfileMenuPage : BasePage
    {
        private string logoutButton = "//div[text()= 'Выйти']";

        public void ClickOnLogoutButton()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(logoutButton))).Click();
        }
    }
}
