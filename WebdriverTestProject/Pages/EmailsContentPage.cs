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
    public class EmailsContentPage : BasePage
    {
        private static int emailsCount;
        private string emailsList = "//div[@class = 'llct__content']";
        private string sentEmailsSubject = "//a[contains(@class, 'llct js-letter-list-item')]//div[@class = 'llct__subject']";
        private string sentEmailsRecipient = "//a[contains(@class, 'llct js-letter-list-item')]//span[@class = 'll-crpt']";
        private string sentEmailsBody = "//a[contains(@class, 'llct js-letter-list-item')]//span[@class = 'll-sp__normal']";

        public void OpenEnEmailFromTheListById(int emailID)
        {
            emailsCount = Helpers.FindElementsByXpath(Driver, emailsList).Count;
            Helpers.FindElementsByXpath(Driver, emailsList)[emailID].Click();
        }

        public bool VerifyThatEmailDisappearsFromDraftsFolderAfterSending()
        {
            Driver.Navigate().Refresh();
            int emailsCountAfterSendingAnEmail = Helpers.FindElementsByXpath(Driver, emailsList).Count;
            return emailsCountAfterSendingAnEmail == 0 || emailsCountAfterSendingAnEmail == emailsCount - 1;
        }

        public bool VerifySentEmailsContent(string recipient, string subject, string bodyText)
        {
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(sentEmailsRecipient)));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(sentEmailsSubject)));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(sentEmailsBody)));
            bool assertRecipient = Helpers.FindElementsByXpath(Driver, sentEmailsRecipient)[0].GetAttribute("title").Equals(recipient);
            bool assertSubject = Helpers.FindElementsByXpath(Driver, sentEmailsSubject)[0].Text.Equals(subject);
            bool assertBody = Helpers.FindElementsByXpath(Driver, sentEmailsBody)[0].Text.Contains(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }
    }
}
