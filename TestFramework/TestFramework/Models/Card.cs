using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Models
{
    class Card
    {
        public string CreditCardNumber { get; set; }
        public string CardholderName { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string CVC { get; set; }

        public Card(string creditCardNumber, string cardholderName, string month, string year, string cvc)
        {
            CreditCardNumber = creditCardNumber;
            CardholderName = cardholderName;
            Month = month;
            Year = year;
            CVC = cvc;
        }
    }
}
