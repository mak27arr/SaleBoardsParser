using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.BaseClasses
{
    class ContactType
    {
        public string Value { get; protected set; }
        private ContactType(string value) { this.Value = value; }

        public static ContactType PhoneNumber { get { return new ContactType("PhoneNumber"); } }
        public static ContactType Email { get { return new ContactType("Email"); } }
        public static ContactType Telegram { get { return new ContactType("Telegram"); } }
        public static ContactType Viber { get { return new ContactType("Viber"); } }
        public static ContactType Skype { get { return new ContactType("Skype"); } }
        public static ContactType Instagram { get { return new ContactType("Instagram"); } }
        public override string ToString()
        {
            return this.Value;
        }
    }
}
