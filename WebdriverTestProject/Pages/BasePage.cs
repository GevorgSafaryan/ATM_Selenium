using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebdriverTestProject.Pages
{
    public class BasePage
    {
        public static IWebDriver Driver { get; set; }
        public static string URL { get; set; }
        public static string Browser { get; set; }
        public static WebDriverWait Wait { get; set; }

        public void Init()
        {
            Browser = ConfigurationManager.AppSettings["browser"];
            URL = ConfigurationManager.AppSettings["url"];
            switch (Browser)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddExcludedArgument("enable-automation");
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    Driver = new ChromeDriver(options);
                    Driver.Url = URL;
                    break;
                case "ff":
                    break;
                case "edge":
                    break;
                default:
                    break;
            }
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(700)
            };
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException));
        }

        public void CleanUp()
        {
            Driver.Dispose();
        }
    }
}
