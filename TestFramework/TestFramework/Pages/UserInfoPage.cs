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

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$btnCheckout")]
        private IWebElement submitButton;

        private By waitLocator = By.Name("ctl00$MainContent$txtEmail");

        public UserInfoPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(waitLocator));
        }

        public UserInfoPage InputUserInfo(UserInfo user)
        {
            email.SendKeys(user.Mail);
            phone.SendKeys(user.PhoneNumber);
            companyName.SendKeys(user.CompanyName);
            city.SendKeys(user.City);
            zipCode.SendKeys(user.ZipCode);
            country.SendKeys(user.Country);
            ((IJavaScriptExecutor)driver).ExecuteScript("scroll(0,1000);", termsAndConditions);
            //Thread.Sleep(7000); mb driver wait, but what use ?
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.Id("evTermCondition")));
            termsAndConditions.Click();
            //Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", acceptParameters);
            acceptParameters.Click();
            return this;
        }

        public PayPage Submit()
        {
            submitButton.Click();
            return new PayPage(driver);
        }
    }
}
