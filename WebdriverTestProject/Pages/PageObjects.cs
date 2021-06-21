using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverTestProject.Pages
{
    public static class PageObjects
    {
        public static BasePage BasePage
        {
            get
            {
                return new BasePage();
            }
        }

        public static HomePage HomePage
        {
            get
            {
                return new HomePage();
            }
        }

        public static HeaderPage Header
        {
            get
            {
                return new HeaderPage();
            }
        }

        public static LeftMenuPage LeftMenu
        {
            get
            {
                return new LeftMenuPage();
            }
        }

        public static CreateEmailPage CreateEmail
        {
            get
            {
                return new CreateEmailPage();
            }
        }

        public static EmailsContentPage EmailsContent
        {
            get
            {
                return new EmailsContentPage();
            }
        }

        public static ProfileMenuPage ProfileMenu
        {
            get
            {
                return new ProfileMenuPage();
            }
        }
    }
}
