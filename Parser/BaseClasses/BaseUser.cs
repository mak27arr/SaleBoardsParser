using SaleBoardsParser.Parser.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SaleBoardsParser.Parser.BaseClasses
{
    class BaseUser : IUser
    {
        private string id;
        private List<Tuple<ContactType, string>> Contacts = new List<Tuple<ContactType, string>>();
        public string Name { get; set; }
        public string Id { get { return id; } set { throw new NotSupportedException(); } }

        public BaseUser(string id)
        {
            this.id = id;
        }

        public void AddContact(ContactType type, string value)
        {
            var contact = new Tuple<ContactType, string>(type, value);
            if (!Contacts.Contains(contact))
            {
                Contacts.Add(contact);
            }
        }

        public string GetContact(ContactType type)
        {
            return Contacts.First(p => p.Item1 == type).Item2;
        }

        public List<string> GetContacts(ContactType type)
        {
            return Contacts.FindAll(x=>x.Item1==type).Select(p => new string(p.Item2)).ToList();
        }

        public List<Tuple<ContactType, string>> GetContacts()
        {
            return Contacts;
        }
    }
}
