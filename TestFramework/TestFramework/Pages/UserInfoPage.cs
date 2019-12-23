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
    class UserInfoPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$txtEmail")]
        private IWebElement email;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$txtBillPhone")]
        private IWebElement phone;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$txtAdd")]
        private IWebElement companyName;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$txtCity")]
        private IWebElement city;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$txtZip")]
        private IWebElement zipCode;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ddlCountry")]
        private IWebElement country;

        [FindsBy(How = How.Id, Using = "evTermCondition")]
        private IWebElement termsAndConditions;

        [FindsBy(How = How.Id, Using = "MainContent_chkMandatory")]
        private IWebElement acceptParameters;

        [FindsBy(How = How.XPath, Using = "//input[@id='btnCheckout']")]
        private IWebElement submitButton;

        private By modalWindowLocator = By.Id("MainContent_updProgress");

        private By waitLocator = By.Name("ctl00$MainContent$txtEmail");

        private By conditionLocator = By.Id("evTermCondition");

        public UserInfoPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            Helper.WaitElementIsVisible(driver, waitLocator, 60);
        }

        public PayPage InputUserInfo(UserInfo user)
        {
            email.SendKeys(user.Mail);
            phone.SendKeys(user.PhoneNumber);
            companyName.SendKeys(user.CompanyName);
            city.SendKeys(user.City);
            zipCode.SendKeys(user.ZipCode);
            country.SendKeys(user.Country);
            Helper.WaitElementIsVisible(driver, modalWindowLocator, 15);
            Helper.WaitInvisibilityOfElementWithText(driver, 15, modalWindowLocator, "UPDATING RESULTS...");
            Helper.ScrollToValue(driver, 1000);
            Helper.WaitElementToBeClickable(driver, conditionLocator, 60);
            termsAndConditions.Click();
            Helper.ScrollToElement(driver, acceptParameters);
            acceptParameters.Click();
            submitButton.Click();// no comments....... it`s awesome)
            submitButton.Click();
            return new PayPage(driver);
        }
    }
}
