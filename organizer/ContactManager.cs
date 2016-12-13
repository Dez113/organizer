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
            contactList.RemoveAt(index);
        }

        public ContactItem ReturnContactItemViaListBoxIndex(int index)
        {
            return (contactList[index]);
        }

        public List<ContactItem> ReturnContactList()
        {
            return contactList;// скорее всего так нельзя (возвращается приватный контактлист)
        }

        public ContactItem ReturnFoundedContact(string stringToFind)
        {
            ContactItem toreturn = null;
            foreach (ContactItem item in contactList)
            {
                string line = item.personName + " \t" + item.personSername + " \t" + item.personAge + " \t" + item.personWebPage;
                if (line.Contains(stringToFind))
                {
                    toreturn = item;
                    break;
                }
            }
            
            return toreturn;
        }

        public int ReturnContactIndex(ContactItem item)
        {
            return contactList.IndexOf(item);
        }
 }
}

