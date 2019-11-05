using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;


namespace WebDriver
{
    [TestClass]
    public class WebTest
    {
        private IWebDriver driver = new ChromeDriver();

        private string errorMessage = "Please enter at least 1 adult, senior or junior(youth) passenger.";

        [TestMethod]
        public void SearchTicketsWithoutAdultPassenger()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.internationalrail.com/");
            SelectCityAndDate(driver);
            var selectAdult =
                new SelectElement(driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$ddlAdult")));
            selectAdult.SelectByValue("0");
            var selectChildren =
                new SelectElement(driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$ddlChild")));
            selectChildren.SelectByValue("1");
            new Actions(driver)
                .SendKeys(
                    driver.FindElement(By.XPath(
                        "/html/body/form/main/div[1]/div[3]/div[2]/div[3]/div/div[2]/div[1]/div[1]/div[9]/label")),
                    Keys.PageDown).Build().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var searchButton = GetElement(driver, "/html/body/form/main/div[1]/div[3]/div[2]/div[3]/div/div[2]/div[1]/div[1]/div[10]/input");
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/form/main/div[1]/div[3]/div[2]/div[3]/div/div[2]/div[1]/div[1]/div[10]/input")));
            searchButton.Click();
            var actualError =
                driver.FindElement(
                    By.XPath("/html/body/form/main/div[1]/div[3]/div[2]/div[3]/div/div[2]/div[3]/div[2]/p[1]"));
            Assert.AreEqual(errorMessage, actualError.Text);
            driver.Quit();
        }

        public void SelectCityAndDate(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$txtFrom")).SendKeys("London (any)");
            webDriver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$txtTo")).SendKeys("Manchester (any)");
            webDriver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$txtDepartureDate")).Click();
            webDriver.FindElement(By.XPath("/html/body/div/table/tbody/tr[5]/td[1]/a")).Click();
        }

        [TestMethod]
        public void SearchTicketsWithoutPassenger()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.internationalrail.com/");
            SelectCityAndDate(driver);
            var selectAdult =
                new SelectElement(driver.FindElement(By.Name("ctl00$MainContent$ucLoyaltyCart$ddlAdult")));
            selectAdult.SelectByValue("0");
            new Actions(driver)
                .SendKeys(
                    driver.FindElement(By.XPath(
                        "/html/body/form/main/div[1]/div[3]/div[2]/div[3]/div/div[2]/div[1]/div[1]/div[9]/label")),
                    Keys.PageDown).Build().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var searchButton = GetElement(driver, "/html/body/form/main/div[1]/div[3]/div[2]/div[3]/div/div[2]/div[1]/div[1]/div[10]/input");
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/form/main/div[1]/div[3]/div[2]/div[3]/div/div[2]/div[1]/div[1]/div[10]/input")));
            searchButton.Click();
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            var actualError = driver.SwitchTo().Alert().Text;
            Assert.AreEqual(errorMessage, actualError);
            driver.Quit();

        }

        IWebElement GetElement(IWebDriver driver, string xPath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                IWebElement webElement = d.FindElement(By.XPath(xPath));
                if (webElement.Displayed)
                    return webElement;
                return null;
            });
            return element;
        }
    }
}