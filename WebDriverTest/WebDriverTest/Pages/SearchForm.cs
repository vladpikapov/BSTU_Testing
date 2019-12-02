using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTest.Pages
{
    class MainPage
    {
        IWebDriver driver;

        [FindsBy(How =How.Name, Using="ctl00$MainContent$ucLoyaltyCart$txtFrom")]
        IWebElement CityFrom { get; set; }

        [FindsBy(How =How.Name, Using="ctl00$MainContent$ucLoyaltyCart$txtTo")]
        IWebElement CityTo { get; set; }

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$txtDepartureDate")]
        IWebElement DatePicker { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-datepicker-div']/table/tbody/tr[4]/td[5]/a")]
        IWebElement CurrentDate { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_ucLoyaltyCart_btnCheckout")]
        IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlAdult")]
        IWebElement AdultSelector { get; set; }

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$ucLoyaltyCart$ddlChild")]
        IWebElement ChildrenSelector { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]")]
        public IWebElement KidsError { get; set; }

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;

        }

        public void InputCityFromAndCityTo(string cityFrom, string cityTo)
        {
            CityFrom.SendKeys(cityFrom);
            CityTo.SendKeys(cityTo);
        }

        public void WaitModalWindow()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='MainContent_ucLoyaltyCart_pnlPassenger']/div[2]/p[1]")));
        }

        public void InputDateDefaultValues()
        {
            DatePicker.Click();
            CurrentDate.Click();
        }

        public void SetAdultsAndChildren(int countAdult, int countChildren)
        {
            new SelectElement(AdultSelector).SelectByValue(countAdult.ToString());
            new SelectElement(ChildrenSelector).SelectByValue(countChildren.ToString());
            
        }

        public void Submit()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", SearchButton);
            SearchButton.Click();
        }
    }
}
