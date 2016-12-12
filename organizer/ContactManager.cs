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

        public class Tuple<ContactItem, int32>
        {
            private ContactItem item;
            private int v;

            public Tuple(ContactItem item, int v)
            {
                this.item = item;
                this.v = v;
            }
        }


        public Tuple<ContactItem, int> ReturnFounded(string stringToFind)
        {
            //public static Tuple<ContactItem, int>;
            //var result1 = Tuple.Create
            //List<object> result = new List<object>();
            foreach(ContactItem item in contactList)
            {
                string line = item.personName + " \t" + item.personSername + " \t" + item.personAge + " \t" + item.personWebPage;
                if (line.Contains(stringToFind))
                {
                    break;
                }
            }
            //var Tuple<ContactItem, int> reuslt1(ContactItem item, int contactList.IndexOf(item))
            Tuple<ContactItem, int> result2 = new Tuple<ContactItem, int>(item, contactList.IndexOf(item));
            //result.Add(item);
            //result.Add(contactList.IndexOf(item));
            return result2;
        }
 }
}

