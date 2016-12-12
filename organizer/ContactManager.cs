using System.Collections.Generic;

namespace organizer
{
    public class ContactManager
    {
        private ContactItem item;

        public ContactManager()
        {
            
        }

        public ContactManager(ContactItem item)
        {
            this.item = item;
        }

        public static List<ContactItem> contactList = new List<ContactItem>();

        public void AddContact(ContactItem item)
        {
            contactList.Add(item);
                        
        }

        public void RemoveContact(int index)
        {
            //
            contactList.RemoveAt(index);
        
        }

    }
}
