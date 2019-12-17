using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class TicketLocationPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$btnSave")]
        private IWebElement bookingDetailsButton;

        private By waitLocator = By.Id("MainContent_lblTVM");

        public TicketLocationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(waitLocator));
        }

        public UserInfoPage Submit()
        {
            bookingDetailsButton.Click();
            return new UserInfoPage(driver);
        }
    }
}
