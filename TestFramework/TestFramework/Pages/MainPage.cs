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
using TestFramework.Services;

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

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'27')]")]
        private IWebElement currentDate;

        [FindsBy(How = How.Id, Using = "MainContent_ucLoyaltyCart_btnCheckout")]
        private IWebElement searchButton;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlAdult")]
        private IWebElement adultSelector;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlChild")]
        private IWebElement childrenSelector;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'ui-datepicker-next ui-corner-all')]")]
        private IWebElement nextMonth;

        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]")]
        private IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//table[@id='MainContent_ucLoyaltyCart_rdBookingType']//label[contains(text(),'Return')]")]
        private IWebElement returnButton;

        private By errorMesageLocator = By.XPath("//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]");

        private By returnDatePickerLocator = By.Name("ctl00$MainContent$ucLoyaltyCart$txtReturnDate");

        private By currentDateLocator = By.XPath("//a[contains(text(),'27')]");

        private By buttonLocator = By.Id("MainContent_ucLoyaltyCart_btnCheckout");

        private By datePickerLocator = By.Name("ctl00$MainContent$ucLoyaltyCart$txtDepartureDate");

        private By bindLocator = By.Id("_bindDivData");

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;

        }

        public MainPage InputCity(SearchForm searchForm)
        {
            cityFrom.SendKeys("");
            cityFrom.SendKeys(searchForm.FromCity);
            cityTo.SendKeys("");
            cityTo.SendKeys(searchForm.ToCity);
            return this;
        }

        public MainPage SetPassengers(SearchForm searchForm)
        {
            new SelectElement(adultSelector).SelectByValue(searchForm.NumberOfAdults);
            new SelectElement(childrenSelector).SelectByValue(searchForm.NumberOfChildren);
            return this;
        }

        public MainPage WaitModalWindow()
        {
            Helper.WaitElementIsVisible(driver, errorMesageLocator, 10);
            return this;
        }
        
        public MainPage InputDateEigthMonthsAdvance(int mountCount)
        {
            datePicker.Click();
            for (int i = 0; i < mountCount; i++)
                nextMonth.Click();
            currentDate.Click();
            return this;
        }

        public MainPage InputDateDefaultValues()
        {
            Helper.ScrollToValue(driver, 500);
            Helper.WaitInvisibilityOfElement(driver, bindLocator, 15);
            datePicker.Click();
            currentDate.Click();
            return this;
        }

        public MainPage InputDateDefaultValuesForReturn()
        {
            Helper.WaitElementToBeClickable(driver, returnDatePickerLocator, 60);
            datePicker.Click();
            currentDate.Click();
            return this;
        }

        public MainPage SubmitReturnDate()
        {
            Helper.WaitElementToBeClickable(driver, buttonLocator, 10);
            Helper.ScrollToElement(driver, searchButton);
            searchButton.Click();
            return this;
        }

        public MainPage Submit()
        {
            Helper.ScrollToElement(driver, searchButton);
            searchButton.Click();
            return this;
        }

        public SelectTheTicketPage SubmitValidValue()
        {
            Helper.ScrollToElement(driver, searchButton);
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
            Helper.ScrollToValue(driver,250);
            Helper.WaitElementToBeClickable(driver, returnDatePickerLocator, 10);
            returnDatePicker.Click();
            Helper.WaitElementToBeClickable(driver, currentDateLocator, 10);
            currentDate.Click();
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
