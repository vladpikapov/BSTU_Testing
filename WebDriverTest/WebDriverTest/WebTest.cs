using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverTest.Pages;
using Assert = NUnit.Framework.Assert;


namespace WebDriver
{

    [TestClass]
    public class WebTest
    {
        MainPage mainPage;
        [TestInitialize]
        public void Initialization()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.internationalrail.com/");
            mainPage = new MainPage(driver);
        }

        [TestCleanup]
        public void Final()
        {
            driver.Quit();
        }
        private IWebDriver driver = new ChromeDriver();

        private string errorMessage = "Please enter at least 1 adult, senior or junior(youth) passenger.";

        [TestMethod]
        public void SearchTicketsWithoutAdultPassenger()
        {
            SelectCityAndDate(driver);
            var selectAdult =
                new SelectElement(driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$ddlAdult")));
            selectAdult.SelectByValue("0");
            var selectChildren =
                new SelectElement(driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$ddlChild")));
            selectChildren.SelectByValue("1");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$btnCheckout")));
            driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$btnCheckout")).Click();
            var actualError =
                driver.FindElement(
                    By.XPath("//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]"));
            Assert.AreEqual(errorMessage, actualError.Text);
        }

        public void SelectCityAndDate(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$txtFrom")).SendKeys("London (any)");
            webDriver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$txtTo")).SendKeys("Manchester (any)");
            webDriver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$txtDepartureDate")).Click();
            webDriver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/table/tbody/tr[4]/td[5]/a")).Click();
        }

        [TestMethod]
        public void SearchTicketsWithoutPassenger()
        { 
            SelectCityAndDate(driver);
            var selectAdult =
                new SelectElement(driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$ddlAdult")));
            selectAdult.SelectByValue("0");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$btnCheckout")));
            driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$btnCheckout")).Click();
            new WebDriverWait(driver,TimeSpan.FromSeconds(20)).Until(ExpectedConditions.AlertIsPresent());
            var actualError = driver.SwitchTo().Alert().Text;
            Assert.AreEqual(errorMessage, actualError);

        }
        
        [TestMethod]
        public void SearchTicketsWithOneAdultAndFiveChildren()
        {
            
            mainPage.InputCityFromAndCityTo("London(any)", "Manchester (any)")
            .InputDateDefaultValues()
            .SetAdultsAndChildren(1, 5)
            .Submit()
            .WaitModalWindow();
            Assert.AreEqual(errorMessage, mainPage.errorMessage.Text);
        }

        [TestMethod]
        public void OrderingATicketToTheSameStation()
        {
            mainPage.InputCityFromAndCityTo("Manchester Victoria", "Manchester Victoria")
            .InputDateDefaultValues()
            .SetAdultsAndChildren(1, 0)
            .Submit();
            ErrorPage error = new ErrorPage(driver);
            Assert.AreEqual("I'm sorry we don't appear to be able " +
                "to do that journey online at the moment," +
                " the chances are we're able to do it offline though." +
                " Please complete the form below and we'll get back to you with a quote.", error.errorMessage.Text);
        }
    }
}