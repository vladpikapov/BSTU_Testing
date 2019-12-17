using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Models;

namespace TestFramework.Services
{
    class UserInfoCreator
    {
        public static UserInfo WithDefaultParameters()
        {
            return new UserInfo(TestParameters.GetData("Title"), TestParameters.GetData("Name"), TestParameters.GetData("Surname"), TestParameters.GetData("Mail"), TestParameters.GetData("PhoneNumber"), TestParameters.GetData("CompanyName"), TestParameters.GetData("City"), TestParameters.GetData("ZipCode"), TestParameters.GetData("Country"));
        } 

        public static UserInfo WithEmptyName()
        {
            return new UserInfo(TestParameters.GetData("Title"), "", "", TestParameters.GetData("Mail"), TestParameters.GetData("PhoneNumber"), TestParameters.GetData("CompanyName"), TestParameters.GetData("City"), TestParameters.GetData("ZipCode"), TestParameters.GetData("Country"));
        }
    }
}
