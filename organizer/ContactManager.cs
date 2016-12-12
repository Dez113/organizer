using System.Collections.Generic;

namespace organizer
{
    public class ContactManager
    {
        private ContactItem item;

        public ContactManager(ContactItem item)
        {
            this.item = item;
        }

        public static List<ContactItem> contactList = new List<ContactItem>();

        public void AddContact(ContactItem item)
        {
            contactList.Add(item);
            //foreach (ContactItem contact in contactList)
            //{
            //    System.Console.WriteLine(contact.personName);
            //}
            
        }

        public void RemoveContact()
        {
            //*
        
        }

    }
}
