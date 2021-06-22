using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTestProject.Pages;

namespace WebdriverTestProject.Utils
{
    public static class Helpers
    {
        public static IWebElement FindElementByXpath(IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByXpath(IWebDriver driver, string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        public static IWebElement FindElementById(IWebDriver driver, string id)
        {
            return driver.FindElement(By.Id(id));
        }

        public static ReadOnlyCollection<IWebElement> FindelementsById(IWebDriver driver, string id)
        {
            return driver.FindElements(By.Id(id));
        }

        public static void SwitchToWindow(IWebDriver driver, int windowID)
        {
            driver.SwitchTo().Window(driver.WindowHandles[windowID]);
        }
    }
}
