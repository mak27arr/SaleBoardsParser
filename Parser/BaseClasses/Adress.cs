using SaleBoardsParser.Parser.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.BaseClasses
{
    class Address : IAddres
    {
        public string Country{get;set;}
        public string State { get; set; }
        public string City { get; set; }
        public string Streat { get; set; }

        public Address(string country,string state,string city)
        {
            this.Country = country;
            this.State = state;
            this.City = city;
        }

        public override string ToString()
        {
            string addres = "";
            return AddToAddressFormat(AddToAddressFormat(AddToAddressFormat(addres,Country),State),City);   
        }
        public string AddToAddressFormat(string addres,string add)
        {
            if (addres.Length > 0 && add.Length > 0)
                addres += ",";
            if (Country.Length > 0)
                addres += Country;
            return addres;
        }
    }
}
