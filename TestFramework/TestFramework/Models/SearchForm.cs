using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Models
{
    class SearchForm
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string NumberOfChildren { get; set; }
        public string NumberOfAdults { get; set; }

        public SearchForm(string fromCity, string toCity, string numberOfChildren, string numberOfAdults)
        {
            FromCity = fromCity;
            ToCity = toCity;
            NumberOfChildren = numberOfChildren;
            NumberOfAdults = numberOfAdults;
        }

    }
}
