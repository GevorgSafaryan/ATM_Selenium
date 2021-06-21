using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;

namespace WebdriverTestProject.Pages
{
    public class ProfileMenuPage : BasePage
    {
        private string logoutButton = "//a[@href = '//auth.mail.ru/cgi-bin/logout?next=1&lang=ru_RU&page=https%3A%2F%2Fmail.ru%2F%3Ffrom%3Dlogout']";

        public void ClickOnLogoutButton()
        {
            Helpers.FindElementByXpath(Driver, logoutButton).Click();
        }
    }
}
