using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverTest.Pages
{
    class MainPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtFrom")]
        IWebElement cityFrom;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtTo")]
        IWebElement cityTo;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtDepartureDate")]
        IWebElement datePicker;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-datepicker-div']/table/tbody/tr[4]/td[5]/a")]
        IWebElement currentDate;

        [FindsBy(How = How.Id, Using = "MainContent_ucLoyaltyCart_btnCheckout")]
        IWebElement searchButton;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlAdult")]
        IWebElement adultSelector;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlChild")]
        IWebElement childrenSelector;

        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]")]
        public IWebElement errorMessage;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;

        }

        public MainPage InputCityFromAndCityTo(string cityFrom, string cityTo)
        {
            this.cityFrom.SendKeys(cityFrom);
            this.cityTo.SendKeys(cityTo);
            return this;
        }

        public MainPage WaitModalWindow()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]")));
            return this;
        }

        public MainPage InputDateDefaultValues()
        {
            datePicker.Click();
            currentDate.Click();
            return this;
        }

        public MainPage SetAdultsAndChildren(int countAdult, int countChildren)
        {
            new SelectElement(adultSelector).SelectByValue(countAdult.ToString());
            new SelectElement(childrenSelector).SelectByValue(countChildren.ToString());
            return this;
        }

        public MainPage Submit()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", searchButton);
            searchButton.Click();
            return this;
        }
    }
}
