using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebdriverTestProject.Pages;

namespace WebdriverTestProject.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            PageObjects.BasePage.Init();
        }

        [TearDown]
        public void TearDown()
        {
            PageObjects.BasePage.CleanUp();
        }
    }
}
