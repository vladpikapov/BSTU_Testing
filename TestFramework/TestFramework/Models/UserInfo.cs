using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Models
{
    class UserInfo
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public UserInfo(string title, string name, string surname, string mail, string phoneNumber, string companyName, string city, string zipCode, string country)
        {
            Title = title;
            Name = name;
            Surname = surname;
            Mail = mail;
            PhoneNumber = phoneNumber;
            CompanyName = companyName;
            City = city;
            ZipCode = zipCode;
            Country = country;
        }
    }
}
