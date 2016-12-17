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

        private static List<ContactItem> contactList = new List<ContactItem>();

        public static void AddContact(ContactItem item)
        {
            contactList.Add(item);

        }

        public static void RemoveContact(int index)
        {
            contactList.RemoveAt(index);
        }

        public static ContactItem ReturnContactItemViaListBoxIndex(int index)
        {
            return (contactList[index]);
        }

        public static List<ContactItem> ReturnContactList()
        {
            return contactList;// скорее всего так нельзя (возвращается приватный контактлист)
        }

        public static ContactItem ReturnFoundedContact(string stringToFind)
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

        public static int ReturnContactIndex(ContactItem item)
        {
            return contactList.IndexOf(item);
        }
 }
}

