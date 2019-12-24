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
using TestFramework.Logging;

namespace TestFramework.Tests
{
    class TestConfig
    {
        protected IWebDriver driver;

        [SetUp]
        public void Initialization()
        {
            Logger.InitLogger();
            driver = Driver.GetDriver();
            driver.Navigate().GoToUrl("https://www.internationalrail.com");
            Logger.Log.Debug("Navigated to https://www.internationalrail.com");
            Logger.Log.Debug("Starting test:" + TestContext.CurrentContext.Test.Name + "...");
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
                Logger.Log.Error("Error:" + TestContext.CurrentContext.Result.Message);
            }
            Logger.Log.Info("Test complete");
            Driver.CloseDriver();
            Logger.Log.Info("Driver closed");
        }
    }
}
