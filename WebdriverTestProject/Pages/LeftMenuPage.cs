using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTestProject.Pages
{
    public class LeftMenuPage : BasePage
    {
        private string composeButton = "//span[@class = 'compose-button__wrapper']";
        private string draftsFolder = "//div[text() = 'Черновики']";
        private string sentFolder = "//a[@href = '/sent/']";
        private string activeFolder = "//a[@class = 'nav__item js-shortcut nav__item_active nav__item_shortcut nav__item_expanded_true nav__item_child-level_0']";

        public void ClickOnComposeButton()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(composeButton))).Click();
        }

        public void OpenDraftsFolder()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(draftsFolder))).Click();
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(activeFolder)));
        }

        public void OpenSentFolder()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(sentFolder))).Click();
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(activeFolder)));
        }
    }
}
