using SaleBoardsParser.Parser.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.BaseInterface
{
    interface IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public void AddContact(ContactType type,string value);
        public string GetContact(ContactType type);
        public List<Tuple<ContactType, string>> GetContacts();
    }
}
