using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestFramework.DriverSingleton;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;

namespace TestFramework.Tests
{
    class TestConfig
    {
        protected IWebDriver driver;

        [SetUp]
        public void Initialization()
        {
            driver = Driver.GetDriver();
            driver.Navigate().GoToUrl("https://www.internationalrail.com");
        }

        [OneTimeTearDown]
        public void TimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
            }
            Driver.CloseDriver();
        }
    }
}
