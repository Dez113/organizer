using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace organizer
{
    public class ContactManager
    {
        
        private static List<ContactItem> contactList = new List<ContactItem>();                             



        public static void save()                                                                       //сохранение данных (сериализация)
        {
            XmlSerializer writer = new XmlSerializer(typeof(ContactItem[]));
            FileStream fs = new FileStream("contactlist.xml", FileMode.Create);
            ContactItem[] cons = new ContactItem[contactList.Count];
            int i = 0;

            foreach (ContactItem item in contactList)
            {
                cons[i] = item;
                //System.Console.WriteLine(item.Name+item.Sername);
                i++;
            }
            writer.Serialize(fs, cons);
            fs.Close();
        }

        public static void read()                                                                       //загрузка данных (сериализация)
        {
            string xmlFile = @"contactlist.xml";

            if (File.Exists(xmlFile) == true)
            {
                XmlSerializer writer = new XmlSerializer(typeof(ContactItem[]));
                FileStream fs = new FileStream(xmlFile, FileMode.OpenOrCreate);
                ContactItem[] cons = (ContactItem[])writer.Deserialize(fs);
                fs.Close();

                for (int i = 0; i < cons.Length; i++)
                {
                    contactList.Add(cons[i]);
                }
            }
            else
            {
                // pass
            }
            
        }

        public static void AddContact(ContactItem item)                                                 // добавление контакта
        {
            contactList.Add(item);
        }

        public static void RemoveContact(ContactItem item)                                              // удаление контакта
        {
            contactList.Remove(item);
        }

        public static ContactItem ReturnContactItemViaListBoxIndex(int index)                           //возвращает объект по индексу (индекс приходит из контролера)
        {
            return (contactList[index]);
        }

        public static string[] ReturnContactList()                                                      //возвращает контактлист (безопасно)
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

        public static ContactItem FoundedContact(string stringToFind)                                   //возвращает первый найденный контакт
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

        public static int ReturnContactIndex(ContactItem item)                                          //возвращает индекс контакта
        {
            return contactList.IndexOf(item);
        }
    }
}

