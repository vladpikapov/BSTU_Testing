using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Models;

namespace TestFramework.Services
{
    class SearchFormCreator
    {
        public static SearchForm WithAllParameters()
        {
            return new SearchForm(TestParameters.GetData("FromCity"), TestParameters.GetData("ToCity"), TestParameters.GetData("NumberOfChildren"), TestParameters.GetData("NumberOfAdults"));
        }

        public static SearchForm WithoutPassengers()
        {
            return new SearchForm(TestParameters.GetData("FromCity"), TestParameters.GetData("ToCity"), TestParameters.GetData("NumberOfChildren"), "0");
        }

        public static SearchForm WithoutAdultPassengers()
        {
            return new SearchForm(TestParameters.GetData("FromCity"), TestParameters.GetData("ToCity"), "1", "0");
        }

        public static SearchForm WithFiveChildren()
        {
            return new SearchForm(TestParameters.GetData("FromCity"), TestParameters.GetData("ToCity"), "5", TestParameters.GetData("NumberOfAdults"));
        }

        public static SearchForm InSameStation()
        {
            return new SearchForm("Manchester Victoria", "Manchester Victoria", TestParameters.GetData("NumberOfChildren"), TestParameters.GetData("NumberOfAdults"));
        }

        public static SearchForm OtherCity()
        {
            return new SearchForm("Minsk", "Baranovichi", TestParameters.GetData("NumberOfChildren"), TestParameters.GetData("NumberOfAdults"));
        }
    }
}
