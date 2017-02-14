using System;
using System.Collections.Generic;
//using static organizer.DataSave;

namespace organizer
{
    public class ContactManager
    {
        private static List<ContactItem> contactList = new List<ContactItem>();

        static ContactManager()
        {
            DataSave.onSave += DataSaving;
            DataSave.onRestore += RestoreContacts;
        }

        public static void UpdateContactList(List<ContactItem> list)                                    //обновление контактлиста (загрузка)
        {
            if (list != null)
            {
                List<ContactItem> contactList = new List<ContactItem> (list);                           //листбокс заполняется нормально  (ТАК МОЖНО????)
                //foreach (ContactItem item in list)//for (int i=0; i < list.Count; i++)                //листбокс не заполняется сразу
                //{
                //    contactList.Add(item);
                //}
                
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
            if (index != -1)
            {
                return (contactList[index]);
            }
            return null;
        }

        public static List<ContactItem> ReturnList ()
        {
            return contactList;
        }

        public static string[] ReturnContactList()                                                      //возвращает контактлист (безопасно)
        {
            string[] contacts = new string[contactList.Count];
            int i = 0;

            foreach (ContactItem item in contactList)
            {
                contacts[i] = item._idx +"\t" + item._name + " \t" + item._sername + " \t" + item._age + " \t" + item._webpage;
                i++;
            }
            return contacts;
        }

        public static ContactItem FoundedContact(string stringToFind)                                   //возвращает первый найденный контакт
        {
            ContactItem toreturn = null;

            foreach (ContactItem item in contactList)
            {
                string line = item._idx + "\t" + item._name + " \t" + item._sername + " \t" + item._age + " \t" + item._webpage;
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

        public static void DataSaving(ref Dictionary<string, object> dict)
        {
            dict.Add("contacts", contactList);
        }
        public static void RestoreContacts(ref Dictionary <string, object> dict)
        {
            
            contactList = ((Newtonsoft.Json.Linq.JArray)dict["contacts"]).ToObject<List<ContactItem>>();
            //Console.WriteLine(contactList);
        }
    }
}

