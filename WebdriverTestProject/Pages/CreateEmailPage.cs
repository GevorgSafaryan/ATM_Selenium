﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;

namespace WebdriverTestProject.Pages
{
    public class CreateEmailPage : BasePage
    {
        private string composeWindow = "//div[@class = 'compose-app compose-app_fix compose-app_popup compose-app_window compose-app_adaptive']";
        private string recipientAndSubject = "//input[@class = 'container--H9L5q size_s--3_M-_']";
        private string body = "//div[contains(@class, 'editable-container')]/div/div[1]";
        private string sendButton = "//span[@data-title-shortcut = 'Ctrl+Enter']";
        private string saveButton = "//span[@data-title-shortcut = 'Ctrl+S']";
        private string headerButtons = "//button[@class = 'container--2lPGK type_base--rkphf color_base--hO-yz']";
        private string enteredRecipient = "//div[@class = 'container--3B3Lm status_base--wsRcM']";
        private string draftedEmailBody = "//div[@class = 'js-helper js-readmsg-msg']/div/div/div/div[1]";
        private string closIconAfterSendingEmail = "//div[@class = 'layer__controls']//span[@class = 'button2__wrapper']";

        public void FillRecipient(string recipient)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //Wait.Until(WaitConditions.IsElementDisplayed(Helpers.FindElementByXpath(Driver, composeWindow)));
            Helpers.FindElementsByXpath(Driver, recipientAndSubject)[0].SendKeys(recipient);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public void FillSubject(string subject)
        {
            Helpers.FindElementsByXpath(Driver, recipientAndSubject)[1].SendKeys(subject);
        }

        public void FillBody(string bodyText)
        {
            Helpers.FindElementByXpath(Driver, body).SendKeys(bodyText);
        }

        public void ClickOnSendButton()
        {
            Helpers.FindElementByXpath(Driver, sendButton).Click();
        }

        public void ClickOnSaveButton()
        {
            Helpers.FindElementByXpath(Driver, saveButton).Click();
        }

        public void CloseNewEmailForm()
        {
            Helpers.FindElementsByXpath(Driver, headerButtons)[2].Click();
        }

        public bool VerifyDraftEmailsContent(string recipient, string subject, string bodyText)
        {
            bool assertRecipient = Helpers.FindElementByXpath(Driver, enteredRecipient).GetAttribute("title").Equals(recipient);
            bool assertSubject = Helpers.FindElementsByXpath(Driver, recipientAndSubject)[1].GetAttribute("value").Equals(subject);
            bool assertBody = Helpers.FindElementByXpath(Driver, draftedEmailBody).Text.Equals(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }

        public void ClickOnCloseButtonAfterSendingEmail()
        {
            Helpers.FindElementByXpath(Driver, closIconAfterSendingEmail).Click();
        }
    }
}
