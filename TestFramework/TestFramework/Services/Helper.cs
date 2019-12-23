using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Services
{
   public static class Helper
    {
        public static void ScrollToElement(IWebDriver driver,IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        public static void ScrollToValue(IWebDriver driver,int value)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"scroll(0,{value});");
        }

        public static void WaitElementToBeClickable(IWebDriver driver,By locator, int time)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitElementIsVisible(IWebDriver driver, By locator, int time)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitInvisibilityOfElementWithText(IWebDriver driver, int time, By locator, string text)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
        }

        public static void WaitInvisibilityOfElement(IWebDriver driver, By locator, int time)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
