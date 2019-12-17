using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.DriverSingleton
{
    public class Driver
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            if(driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                }
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
        
    }
}
