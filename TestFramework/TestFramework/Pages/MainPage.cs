using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestFramework.Models;

namespace TestFramework.Pages
{
    class MainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtFrom")]
        private IWebElement cityFrom;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtTo")]
        private IWebElement cityTo;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtDepartureDate")]
        private IWebElement datePicker;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtReturnDate")]
        private IWebElement returnDatePicker;

        [FindsBy(How = How.XPath, Using = "/html/body/div/table/tbody/tr[5]/td[4]/a")]
        private IWebElement currentDate;

        [FindsBy(How = How.XPath, Using = "/html/body/div/table/tbody/tr[5]/td[4]/a")]
        private IWebElement returnDate;

        [FindsBy(How = How.Id, Using = "MainContent_ucLoyaltyCart_btnCheckout")]
        private IWebElement searchButton;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlAdult")]
        private IWebElement adultSelector;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlChild")]
        private IWebElement childrenSelector;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-datepicker-div']/div[1]/a[2]")]
        private IWebElement nextMonth;

        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]")]
        private IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent_ucLoyaltyCart_rdBookingType']/tbody/tr/td[2]/label")]
        private IWebElement returnButton;

        private By errorMesageLocator = By.XPath("//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]");

        private By returnDatePickerLocator = By.Name("ctl00$MainContent$ucLoyaltyCart$txtReturnDate");

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;

        }

        public MainPage InputCityAndSetPassengers(SearchForm searchForm)
        {
            cityFrom.SendKeys("");
            cityFrom.SendKeys(searchForm.FromCity);
            cityTo.SendKeys("");
            cityTo.SendKeys(searchForm.ToCity);
            new SelectElement(adultSelector).SelectByValue(searchForm.NumberOfAdults);
            new SelectElement(childrenSelector).SelectByValue(searchForm.NumberOfChildren);
            return this;
        }

        public MainPage WaitModalWindow()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(errorMesageLocator));
            return this;
        }
        
        public MainPage InputDateEigthMonthsAdvance()
        {
            datePicker.Click();
            for (int i = 0; i < 8; i++)
                nextMonth.Click();
            currentDate.Click();
            return this;
        }

        public MainPage InputDateDefaultValues()
        {
            datePicker.Click();
            currentDate.Click();
            return this;
        }

        public MainPage InputDateDefaultValuesForReturn()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(returnDatePickerLocator));
            datePicker.Click();
            currentDate.Click();
            return this;
        }

        public MainPage SubmitReturnDate()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.Id("MainContent_ucLoyaltyCart_btnCheckout")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", searchButton);
            searchButton.Click();
            return this;
        }

        public MainPage Submit()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", searchButton);
            searchButton.Click();
            return this;
        }

        public SelectTheTicketPage SubmitValidValue()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", searchButton);
            searchButton.Click();
            return new SelectTheTicketPage(driver);
        }

        public MainPage ReturnSearchClick()
        {
            returnButton.Click();
            return this;
        }

        public MainPage SetEqualsReturnDateAndDepartureDate()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("scroll(0,250);");
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(returnDatePickerLocator));
            returnDatePicker.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div/table/tbody/tr[5]/td[4]/a")));
            returnDate.Click();
            return this;

        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }

        public string GetAlertErrorMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }

    }
}
