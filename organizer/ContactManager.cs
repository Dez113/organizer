using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace organizer
{
    public class ContactManager
    {
        public ContactManager()
        {

        }   
                
        public static List<ContactItem> contactList = new List<ContactItem>();



        public static void save()
        {
            XmlSerializer writer = new XmlSerializer(typeof(ContactItem));
            foreach(ContactItem item in contactList)
            {
                System.Console.WriteLine(item.Name+item.Sername);
                using (FileStream fs = new FileStream("contactlist.xml", FileMode.OpenOrCreate))
                {
                    writer.Serialize(fs, item);
                }
            }
        }

        public static void read()
        {
            XmlSerializer writer = new XmlSerializer(typeof(ContactItem));
            using (FileStream fs = new FileStream("contactlist.xml", FileMode.OpenOrCreate))
            {
                ContactItem item =  (ContactItem)writer.Deserialize(fs);
                contactList.Add(item);
            }
        }

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

