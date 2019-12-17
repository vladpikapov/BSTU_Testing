using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Models;

namespace TestFramework.Pages
{
    class PayPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[1]/div[2]/div/div/input")]
        private IWebElement creditCardNumber;

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[1]/div[3]/div/div/input")]
        private IWebElement cardholderName;

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[1]/div[4]/div/div/select[1]")]
        private IWebElement month;

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[1]/div[4]/div/div/select[2]")]
        private IWebElement year;

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[1]/div[5]/div/div/input")]
        private IWebElement cvc;

        [FindsBy(How = How.Id, Using = "lblErrorMsg")]
        private IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[1]/div[6]/div[2]/label/span/span")]
        private IWebElement acceptParameters;

        [FindsBy(How = How.Name, Using = "submitBtn")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "/html/body/form/main/div[1]/div/div[5]/div[1]/div[3]/div[2]/div[4]/p[2]")]
        private IWebElement checkResult;

        private By waitLocator = By.XPath("/html/body/form/main/div[1]/div/div[5]/div[1]/div[3]/div[2]/div[4]/p[2]"); 

        public PayPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(waitLocator));
        }

        public PayPage InputCardParameters(Card card)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", creditCardNumber);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[1]/div[2]/div/div/input")));
            creditCardNumber.SendKeys(card.CreditCardNumber);
            cardholderName.SendKeys(card.CardholderName);
            new SelectElement(month).SelectByValue(card.Month);
            new SelectElement(year).SelectByValue(card.Year);
            cvc.SendKeys(card.CVC);
            return this;
        }

        public PayPage Submit()
        {
            acceptParameters.Click();
            submitButton.Click();
            return this;
        }

        public bool CheckResult()
        {
            return checkResult.Text.Equals("09:24 | 27 Dec 2019");
        }

        public bool IsNotValid()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.Id("lblErrorMsg")));
            return errorMessage.Text.Equals("Payment has been declined or invalid details.");
        }
    }
}
