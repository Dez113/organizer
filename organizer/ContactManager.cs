﻿using System.Collections.Generic;


namespace organizer
{
    public class ContactManager
    {
        private static List<ContactItem> contactList = new List<ContactItem>();
        

        public static void UpdateContactList(List<ContactItem> list)                                         //обновление контактлиста (загрузка)
        {
            if (list != null)
            {
                foreach (ContactItem item in list)//for (int i=0; i < list.Count; i++)
                {
                    contactList.Add(item);
                }
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
                contacts[i] = item.idx +"\t" + item._name + " \t" + item._sername + " \t" + item._age + " \t" + item._webpage;
                i++;
            }
            return contacts;
        }

        public static ContactItem FoundedContact(string stringToFind)                                   //возвращает первый найденный контакт
        {
            ContactItem toreturn = null;

            foreach (ContactItem item in contactList)
            {
                string line = item.idx + "\t" + item._name + " \t" + item._sername + " \t" + item._age + " \t" + item._webpage;
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

