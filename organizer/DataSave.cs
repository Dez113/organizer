﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace organizer
{
    //[Serializable]
    //public class DataContainer                                                                  //  класс-контейнер для сериализации
    //{
    //    public List<ContactItem> contactlist;
    //    public List<NoteItem> notelist;
    //    public int idx_counter;



    //    public DataContainer()
    //    {
    //        contactlist = ContactManager.ReturnList();
    //        notelist = NoteManager.ReturnListN();

    //        if (contactlist.Count == 0)                                                         // если список контактов пуст сериализируется idx_counter=0
    //        {
    //            idx_counter = 0;
    //        }
    //        else
    //        {
    //            idx_counter = ContactItem.idx_counter;
    //        }
    //    }

    //public IDictionary<string, object> BuildDict()
    //{
    //    dict.Add("contacts", ContactManager.ReturnList());
    //    dict.Add("contacts_idx", ContactItem.idx_counter);
    //    dict.Add("notes", NoteManager.ReturnListN());
    //    return dict;
    //}
    //}

    //class DataSave2                                                                              // рабочий класс
    //{
    //    public static void Save()
    //    {
    //        List<ContactItem> list = ContactManager.ReturnList();

    //        XmlSerializer saver = new XmlSerializer(typeof(List<ContactItem>));
    //        FileStream fs = new FileStream("contactlist.xml", FileMode.Create);
    //        saver.Serialize(fs, list);
    //        fs.Close();
    //    }

    //    public static void Restore()
    //    {
    //        string xmlFile = @"contactlist.xml";

    //        if (File.Exists(xmlFile) == true)
    //        {
    //            XmlSerializer writer = new XmlSerializer(typeof(ContactItem[]));                   // почему-то не получается десериализовать в тип List<ContactItem>
    //            FileStream fs = new FileStream(xmlFile, FileMode.OpenOrCreate);
    //            ContactItem[] list = (ContactItem[])writer.Deserialize(fs);
    //            fs.Close();
    //            //ContactManager.UpdateContactList(list);
    //        }
    //        else
    //        {
    //            //ContactItem[] list = null;
    //            //ContactManager.UpdateContactList(list);
    //        }
    //    }
    //}

    public class DataSave
    {
        public static Dictionary<string, object> dict = new Dictionary<string, object>();
        //onSave(ref dict)
        public delegate void DataSaving(ref Dictionary<string, object> dict);
        public static DataSaving onSave;

        public static void Save()
        {
            onSave(ref dict);
            XmlSerializer saver = new XmlSerializer(typeof(Dictionary<string, object>));
            FileStream fs = new FileStream("test1.xml", FileMode.Create);
            saver.Serialize(fs, dict);
            fs.Close();
            

        }
    }
}
    


    //public static void Save()
    //{
    //    DataContainer mainContainer1 = new DataContainer();
    //    XmlSerializer saver = new XmlSerializer(typeof(DataContainer));
    //    FileStream fs = new FileStream("test.xml", FileMode.Create);
    //    saver.Serialize(fs, mainContainer1);
    //    fs.Close();
    //}

    //public static void Restore()                                                             // не рабочий метод, сначала сделать метод Save 
    //    {
    //        string xmlFile = @"test.xml";

    //        if (File.Exists(xmlFile) == true)
    //        {
    //            XmlSerializer writer = new XmlSerializer(typeof(DataContainer));
    //            FileStream fs = new FileStream(xmlFile, FileMode.Open);
    //            DataContainer mainContainer = (DataContainer)writer.Deserialize(fs);
    //            fs.Close();
    //            ContactManager.UpdateContactList(mainContainer.contactlist);
    //            ContactItem.Update_Counter(mainContainer.idx_counter);
    //            NoteManager.UpdateNoteList(mainContainer.notelist);
    //        }
    //    }
    //}
