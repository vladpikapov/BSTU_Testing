using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class ErrorPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "MainContent_errorMsg")]
        private IWebElement errorMessage;

        private By errorMessageLocator = By.Id("MainContent_errorMsg");

        public ErrorPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(errorMessageLocator));
        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }
    }
}
