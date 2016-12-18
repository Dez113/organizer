using System.Collections.Generic;

namespace organizer
{
    public class ContactManager
    {
        private static List<ContactItem> contactList = new List<ContactItem>();



        public static void AddContact(ContactItem item)
        {
            contactList.Add(item);
        }

        public static void RemoveContact(ContactItem item)
        {
            contactList.Remove(item);
        }

        public static ContactItem ReturnContactItemViaListBoxIndex(int index)
        {
            return (contactList[index]);
        }

        public static string[] ReturnContactList()
        {
            string[] contacts = new string[contactList.Count];
            int i = 0;
            foreach (ContactItem item in contactList)
            {
                contacts[i] = item.Name + " \t" + item.Sername + " \t" + item.Age + " \t" + item.WebPage;
                i++;
            }
            return contacts;
        }

        public static ContactItem FoundedContact(string stringToFind)
        {
            ContactItem toreturn = null;
            foreach (ContactItem item in contactList)
            {
                string line = item.Name + " \t" + item.Sername + " \t" + item.Age + " \t" + item.WebPage;
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

