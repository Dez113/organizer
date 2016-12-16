using System.Collections.Generic;

namespace organizer
{
    public class ContactManager
    {
        private NoteItem item;

        public ContactManager()
        {

        }

        public ContactManager(NoteItem item)
        {
            this.item = item;
        }

        private static List<NoteItem> contactList = new List<NoteItem>();

        public static void AddContact(NoteItem item)
        {
            contactList.Add(item);

        }

        public static void RemoveContact(int index)
        {
            contactList.RemoveAt(index);
        }

        public static NoteItem ReturnContactItemViaListBoxIndex(int index)
        {
            return (contactList[index]);
        }

        public static List<NoteItem> ReturnContactList()
        {
            return contactList;// скорее всего так нельзя (возвращается приватный контактлист)
        }

        public static NoteItem ReturnFoundedContact(string stringToFind)
        {
            NoteItem toreturn = null;
            foreach (NoteItem item in contactList)
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

        public static int ReturnContactIndex(NoteItem item)
        {
            return contactList.IndexOf(item);
        }
 }
}

