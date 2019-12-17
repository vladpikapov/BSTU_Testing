using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Models;

namespace TestFramework.Services
{
    class CardCreator
    {
        public static Card DefaultParameters()
        {
            return new Card(TestParameters.GetData("CreditCardNumber"), TestParameters.GetData("CardholderName"), TestParameters.GetData("Month"), TestParameters.GetData("Year"), TestParameters.GetData("CVC"));
        }
    }
}
