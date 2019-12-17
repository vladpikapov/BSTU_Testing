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
    class SelectSeatsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$btnSave")]
        private IWebElement bookingDetailsButton;

        private By buttonLocator = By.Name("ctl00$MainContent$btnSave");

        public SelectSeatsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(buttonLocator));
        }

        public TicketLocationPage Submit()
        {
            bookingDetailsButton.Click();
            return new TicketLocationPage(driver);
        }
    }
}
