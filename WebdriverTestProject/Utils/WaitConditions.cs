using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverTestProject.Utils
{
    public static class WaitConditions
    {
        public static Func<IWebDriver, bool> IsElementDisplayed(IWebElement element)
        {
            bool condition (IWebDriver driver)
            {
                return element.Displayed;
            }
            return condition;
        }

        public static Func<IWebDriver, IWebElement> ElementDisplayed(IWebElement element)
        {
            IWebElement condition (IWebDriver driver)
            {
                try
                {
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch(ElementNotVisibleException)
                {
                    return null;
                }
            }
            return condition;
        }
    }
}
