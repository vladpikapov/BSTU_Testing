﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTest.Pages
{
    class ErrorPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "MainContent_errorMsg")]
        public IWebElement errorMessage;
        
        public ErrorPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_errorMsg")));
        }

    }
}
