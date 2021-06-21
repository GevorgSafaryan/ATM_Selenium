using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Utils;

namespace WebdriverTestProject.Pages
{
    public class EmailsContentPage : BasePage
    {
        private static int emailsCount;
        private string emailsList = "//a[contains(@class, 'llct js-letter-list-item')]";
        private string sentEmailsSubject = "//h2[@class = 'thread__subject']";
        private string sentEmailsRecipient = "//div[@class = 'letter__recipients letter__recipients_short']//span[@class = 'letter-contact']";
        private string sentEmailsBody = "//div[@data-signature-widget= 'container']/../div[1]";

        public void OpenEnEmailFromTheListById(int emailID)
        {
            emailsCount = Helpers.FindElementsByXpath(Driver, emailsList).Count;
            Helpers.FindElementsByXpath(Driver, emailsList)[emailID].Click();
        }

        public bool VerifyThatEmailDisappearsFromDraftsFolderAfterSending()
        {
            int emailsCountAfterSendingAnEmail = Helpers.FindElementsByXpath(Driver, emailsList).Count;
            return emailsCountAfterSendingAnEmail == 0 || emailsCountAfterSendingAnEmail == emailsCount - 1;
        }

        public bool VerifySentEmailsContent(string recipient, string subject, string bodyText)
        {
            bool assertRecipient = Helpers.FindElementByXpath(Driver, sentEmailsRecipient).GetAttribute("title").Equals(recipient);
            bool assertSubject = Helpers.FindElementByXpath(Driver, sentEmailsSubject).Text.Equals(subject);
            bool assertBody = Helpers.FindElementByXpath(Driver, sentEmailsBody).Text.Equals(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }
    }
}
