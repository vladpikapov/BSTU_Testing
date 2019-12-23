﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Models;
using TestFramework.Services;

namespace TestFramework.Pages
{
    class SelectTheTicketPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html/body/form/main/div[1]/div[1]/div[2]/div[1]/div/div[4]/div[2]/div/div/div[1]/div[1]/div[3]/div/div[2]/div[3]/div[2]/label/span/span")]
        private IWebElement selectClass;

        [FindsBy(How = How.Id, Using = "MainContent_ucSResultEvolvi_rptoutEvolvi_btnContinueBooking_0")]
        private IWebElement bookingDetailsButton;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucSResultEvolvi$rptPassengerDetails$ctl01$txtFirstname")]
        private IWebElement inputFirstName;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucSResultEvolvi$rptPassengerDetails$ctl01$txtLastname")]
        private IWebElement inputLastName;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucSResultEvolvi$rptPassengerDetails$ctl01$ddlTitle")]
        private IWebElement title;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucSResultEvolvi$btnContinue")]
        private IWebElement continueButton;

        private By waitingPageElement = By.Id("MainContent_ucSResultEvolvi_rptoutEvolvi_btnContinueBooking_0");

        private By waitModalWindow = By.Id("MainContent_ucSResultEvolvi_pnlQuckLoad");

        private By selectClassLocator = By.XPath("/html/body/form/main/div[1]/div[1]/div[2]/div[1]/div/div[4]/div[2]/div/div/div[1]/div[1]/div[3]/div/div[2]/div[3]/div[2]/label/span/span");

        public SelectTheTicketPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            Helper.WaitElementIsVisible(driver, waitingPageElement, 60);
        }

        public SelectTheTicketPage SelectClass()
        {
            Helper.WaitElementIsVisible(driver, selectClassLocator, 10);
            selectClass.Click();
            return this;
        }
        
        public SelectTheTicketPage Continue()
        {
            continueButton.Click();
            return this;
        }
        
        public SelectSeatsPage ContinueWithValidParameters()
        {
            continueButton.Click();
            return new SelectSeatsPage(driver);
        }

        public SelectTheTicketPage Submit()
        {
            bookingDetailsButton.Click();
            return this;
        }

        public SelectTheTicketPage WaitModalWindow()
        {
            Helper.WaitElementIsVisible(driver, waitModalWindow, 60);
            return this;
        }

        public SelectTheTicketPage InputUserInfo(UserInfo user)
        {
            new SelectElement(title).SelectByValue(user.Title);
            inputFirstName.SendKeys(user.Name);
            inputLastName.SendKeys(user.Surname);
            return this;
        }

        public string IsInvalidValue()
        {
            string classValue = inputFirstName.GetAttribute("class");
            return classValue;
        }
    }
}