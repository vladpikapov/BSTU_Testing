using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Pages;
using TestFramework.Services;

namespace TestFramework.Tests
{
    class AllTests:TestConfig
    {
        [Test]
        [Category("SearchCategory")]
        public void SearchTicketsWithOneAdultAndFiveChildren()
        {

          string message = new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
                .SetPassengers(SearchFormCreator.WithFiveChildren())
                .InputDateDefaultValues()
                .Submit()
                .WaitModalWindow().GetErrorMessage();
            Assert.AreEqual("Please enter at least 1 adult, senior or junior(youth) passenger.", message);
        }

        //[Test]
        //[Category("SearchCategory")]
        //public void OrderingATicketToTheSameStation()
        //{
        //    new MainPage(driver).InputCity(SearchFormCreator.InSameStation())
        //        .SetPassengers(SearchFormCreator.InSameStation())
        //        .InputDateDefaultValues()
        //        .Submit();
        //    Assert.AreEqual("I'm sorry we don't appear to be able " +
        //        "to do that journey online at the moment," +
        //        " the chances are we're able to do it offline though." +
        //        " Please complete the form below and we'll get back to you with a quote.", new ErrorPage(driver).GetErrorMessage());
        //}

        //[Test]
        //[Category("SearchCategory")]
        //public void SearchTicketsWithoutAdultPassengers()
        //{
        //    string message = new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .SetPassengers(SearchFormCreator.WithoutAdultPassengers())
        //        .InputDateDefaultValues()
        //        .Submit()
        //        .GetErrorMessage();

        //    Assert.AreEqual("Please enter at least 1 adult, senior or junior(youth) passenger.", message);
        //}

        //[Test]
        //[Category("SearchCategory")]
        //public void SearchTicketsWithoutPassengers()
        //{
        //    string message = new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .SetPassengers(SearchFormCreator.WithoutPassengers())
        //        .InputDateDefaultValues()
        //        .Submit()
        //        .GetAlertErrorMessage();
        //    Assert.AreEqual("Please enter at least 1 adult, senior or junior(youth) passenger.", message);
        //}

        //[Test]
        //[Category("DateCategory")]
        //public void SearchTicketForEightMonthsInAdvance()
        //{
        //    new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .SetPassengers(SearchFormCreator.WithAllParameters())
        //        .InputDateEigthMonthsAdvance(8)
        //        .Submit();
        //    Assert.AreEqual("I'm sorry we don't appear to be able " +
        //       "to do that journey online at the moment," +
        //       " the chances are we're able to do it offline though." +
        //       " Please complete the form below and we'll get back to you with a quote.", new ErrorPage(driver).GetErrorMessage());
        //}

        //[Test]
        //[Category("DateCategory")]
        //public void SearchTicketWithEqualDepartureAndReturnDate()
        //{
        //    new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .ReturnSearchClick()
        //        .InputDateDefaultValuesForReturn()
        //        .SetEqualsReturnDateAndDepartureDate()
        //        .SubmitReturnDate();
        //    Assert.AreEqual("I'm sorry we don't appear to be able " +
        //     "to do that journey online at the moment," +
        //     " the chances are we're able to do it offline though." +
        //     " Please complete the form below and we'll get back to you with a quote.", new ErrorPage(driver).GetErrorMessage());
        //}

        //[Test]
        //[Category("SearchCategory")]
        //public void SearchTicketWithNonExistingStations()
        //{
        //    new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .SetPassengers(SearchFormCreator.WithAllParameters())
        //        .InputDateDefaultValues()
        //        .Submit();
        //    Assert.AreEqual("I'm sorry we don't appear to be able " +
        //    "to do that journey online at the moment," +
        //    " the chances are we're able to do it offline though." +
        //    " Please complete the form below and we'll get back to you with a quote.", new ErrorPage(driver).GetErrorMessage());
        //}

        //[Test]
        //[Category("UserCategory")]
        //public void SetEmptyUserInfo()
        //{
        //  SelectTheTicketPage selectTheTicketPage =  new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .SetPassengers(SearchFormCreator.WithAllParameters())
        //        .InputDateDefaultValues()
        //        .SubmitValidValue();
        //    string className = selectTheTicketPage.SelectClass()
        //        .Submit()
        //        .WaitModalWindow()
        //        .InputUserInfo(UserInfoCreator.WithEmptyName())
        //        .Continue()
        //        .IsInvalidValue();
        //    Assert.AreEqual("starail-Form-input starail-Form-error", className);
        //}

        //[Test]
        //[Category("UserCategory")]
        //public void CheckResult()
        //{
        //    SelectTheTicketPage selectTheTicketPage = new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .SetPassengers(SearchFormCreator.WithAllParameters())
        //        .InputDateDefaultValues()
        //        .SubmitValidValue();
        //    SelectSeatsPage selectSeatsPage = selectTheTicketPage.SelectClass()
        //        .Submit()
        //        .WaitModalWindow()
        //        .InputUserInfo(UserInfoCreator.WithDefaultParameters())
        //        .ContinueWithValidParameters();
        //    TicketLocationPage ticketLocationPage = selectSeatsPage.Submit();
        //    UserInfoPage userInfoPage = ticketLocationPage.Submit();
        //    PayPage payPage = userInfoPage.InputUserInfo(UserInfoCreator.WithDefaultParameters());
        //    Assert.AreEqual("10:46 | 27 Dec 2019", payPage.GetResult());
        //}


        //[Test]
        //[Category("UserCategory")]
        //public void InputInvalidCardParameters()
        //{
        //    SelectTheTicketPage selectTheTicketPage = new MainPage(driver).InputCity(SearchFormCreator.WithAllParameters())
        //        .SetPassengers(SearchFormCreator.WithAllParameters())
        //        .InputDateDefaultValues()
        //        .SubmitValidValue();
        //    SelectSeatsPage selectSeatsPage = selectTheTicketPage.SelectClass()
        //        .Submit()
        //        .WaitModalWindow()
        //        .InputUserInfo(UserInfoCreator.WithDefaultParameters())
        //        .ContinueWithValidParameters();
        //    TicketLocationPage ticketLocationPage = selectSeatsPage.Submit();
        //    UserInfoPage userInfoPage = ticketLocationPage.Submit();
        //    PayPage payPage = userInfoPage.InputUserInfo(UserInfoCreator.WithDefaultParameters());
        //    string message = payPage.InputCardEmptyParameters()
        //        .Submit()
        //        .GetAlertErrorMessage();
        //    Assert.AreEqual("Please enter card number.",message);
        //}
    }
}
