using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebdriverTestProject.Pages;
using WebdriverTestProject.Utils;

namespace WebdriverTestProject.Tests
{
    public class TestScenarios : BaseTest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        [OneTimeSetUp]
        public void SetupCredetials()
        {
            Login = JsonConvertor.GetTestData().Login;
            Password = JsonConvertor.GetTestData().Password;
            Recipient = JsonConvertor.GetTestData().Recipient;
            Subject = JsonConvertor.GetTestData().Subject;
            Body = JsonConvertor.GetTestData().Body;
        }

        [Test]
        public void SuccessfullyLoginTest()
        {
            PageObjects.HomePage.Login(Login, Password);
            Assert.IsTrue(PageObjects.Header.VerifySuccessfulLogin(Login));
        }

        [Test]
        public void TestTheCreationOfDraftEmail()
        {
            PageObjects.HomePage.Login(Login, Password);
            PageObjects.LeftMenu.ClickOnComposeButton();
            PageObjects.CreateEmail.FillRecipient(Recipient);
            PageObjects.CreateEmail.FillSubject(Subject);
            PageObjects.CreateEmail.FillBody(Body);
            PageObjects.CreateEmail.ClickOnSaveButton();
            PageObjects.CreateEmail.CloseNewEmailForm();
            PageObjects.LeftMenu.OpenDraftsFolder();
            PageObjects.EmailsContent.OpenEnEmailFromTheListById(0);
            Assert.IsTrue(PageObjects.CreateEmail.VerifyDraftEmailsContent(Recipient, Subject, Body));
        }

        [Test]
        public void TestDraftsFolderAfterSendingTheMail()
        {
            PageObjects.HomePage.Login(Login, Password);
            PageObjects.LeftMenu.ClickOnComposeButton();
            PageObjects.CreateEmail.FillRecipient(Recipient);
            PageObjects.CreateEmail.FillSubject(Subject);
            PageObjects.CreateEmail.FillBody(Body);
            PageObjects.CreateEmail.ClickOnSaveButton();
            PageObjects.CreateEmail.CloseNewEmailForm();
            PageObjects.LeftMenu.OpenDraftsFolder();
            PageObjects.EmailsContent.OpenEnEmailFromTheListById(0);
            PageObjects.CreateEmail.ClickOnSendButton();
            PageObjects.CreateEmail.ClickOnCloseButtonAfterSendingEmail();
            Assert.IsTrue(PageObjects.EmailsContent.VerifyThatEmailDisappearsFromDraftsFolderAfterSending());
        }

        [Test]
        public void TestThatEmailIsInSentFolderAfterSending()
        {
            PageObjects.HomePage.Login(Login, Password);
            PageObjects.LeftMenu.ClickOnComposeButton();
            PageObjects.CreateEmail.FillRecipient(Recipient);
            PageObjects.CreateEmail.FillSubject(Subject);
            PageObjects.CreateEmail.FillBody(Body);
            PageObjects.CreateEmail.ClickOnSaveButton();
            PageObjects.CreateEmail.CloseNewEmailForm();
            PageObjects.LeftMenu.OpenDraftsFolder();
            PageObjects.EmailsContent.OpenEnEmailFromTheListById(0);
            PageObjects.CreateEmail.ClickOnSendButton();
            PageObjects.CreateEmail.ClickOnCloseButtonAfterSendingEmail();
            PageObjects.LeftMenu.OpenSentFolder();
            PageObjects.EmailsContent.OpenEnEmailFromTheListById(0);
            Assert.IsTrue(PageObjects.EmailsContent.VerifySentEmailsContent(Recipient, Subject, Body));
        }

        [Test]
        public void TestSuccessfullyLogout()
        {
            PageObjects.HomePage.Login(Login, Password);
            PageObjects.Header.OpenProfileMenu();
            PageObjects.ProfileMenu.ClickOnLogoutButton();
            Assert.IsTrue(PageObjects.HomePage.VerifySuccessfullLogout());
        }
    }
}
