using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;

namespace WebdriverTestProject.Pages
{
    public class LeftMenuPage : BasePage
    {
        private string composeButton = "//span[@class = 'compose-button__wrapper']";
        private string draftsFolder = "//div[text() = 'Черновики']";
        private string sentFolder = "//a[@href = '/sent/']";

        public void ClickOnComposeButton()
        {
            //Wait.Until(WaitConditions.ElementDisplayed(Helpers.FindElementByXpath(Driver, composeButton))).Click();
            Helpers.FindElementByXpath(Driver, composeButton).Click();
        }

        public void OpenDraftsFolder()
        {
            //System.Threading.Thread.Sleep(20000);
            IWebElement element = Helpers.FindElementByXpath(Driver, draftsFolder);
            Wait.Until(WaitConditions.IsElementDisplayed(element));
            Helpers.FindElementByXpath(Driver, draftsFolder).Click();
        }

        public void OpenSentFolder()
        {
            Helpers.FindElementByXpath(Driver, sentFolder).Click();
        }
    }
}
