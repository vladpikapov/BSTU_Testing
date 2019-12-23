using OpenQA.Selenium;
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
    class PayPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@id='cardnumber']")]
        private IWebElement creditCardNumber;

        [FindsBy(How = How.XPath, Using = "//input[@id='cardname']")]
        private IWebElement cardholderName;

        [FindsBy(How = How.XPath, Using = "//select[@id='expiremonth']")]
        private IWebElement month;

        [FindsBy(How = How.XPath, Using = "//select[@id='expireyear']")]
        private IWebElement year;

        [FindsBy(How = How.XPath, Using = "//input[@id='cvc']")]
        private IWebElement cvc;

        [FindsBy(How = How.Id, Using = "lblErrorMsg")]
        private IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//span[@class='starail-Form-fancyCheckbox']//span")]
        private IWebElement acceptParameters;

        [FindsBy(How = How.XPath, Using = "//input[@id='submitBtn']")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "/html/body/form/main/div[1]/div/div[5]/div[1]/div[3]/div[2]/div[4]/p[2]")]
        private IWebElement checkResult;

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_txtDiscountCode']")]
        private IWebElement waitElement;

        private By cardNameLocator = By.Id("cardname");

        private By errorMessageLocator = By.Id("lblErrorMsg");

        private By waitElementLocator = By.XPath("//input[@id='MainContent_txtDiscountCode']");

        


        public PayPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            Helper.WaitElementIsVisible(driver, waitElementLocator, 10);
        }

        public PayPage InputCardParameters(Card card)
        {
            Helper.ScrollToValue(driver, 750);
            Helper.WaitElementIsVisible(driver, cardNameLocator, 40);
            creditCardNumber.SendKeys(card.CreditCardNumber);
            cardholderName.SendKeys(card.CardholderName);
            new SelectElement(month).SelectByValue(card.Month);
            new SelectElement(year).SelectByValue(card.Year);
            Helper.ScrollToElement(driver, acceptParameters);
            cvc.SendKeys(card.CVC);
            return this;
        }

        public PayPage InputCardEmptyParameters()
        {
            Helper.ScrollToValue(driver, 1000);
            return this;
        }

        public PayPage Submit()
        {
            Helper.ScrollToElement(driver, submitButton);
            submitButton.Click();
            return this;
        }

        public string GetAlertErrorMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }
        public string GetResult()
        {
            return checkResult.Text;
        }

        public string GetErrorMessageValid()
        {
            Helper.WaitElementIsVisible(driver, errorMessageLocator, 30);
            return errorMessage.Text;
        }
    }
}
