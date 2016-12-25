using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace organizer
{
    [Serializable]
    public class DataContainer                                                          //  класс-контейнер для сериализации
    {
        public List<ContactItem> contactlist;
        public List<NoteItem> notelist;
        public int idx;

        //public DataContainer()
        //{

        //}

        public DataContainer()
        {
            contactlist = ContactManager.ReturnList();
            notelist = NoteManager.ReturnListN();
            idx = ContactItem.idx_counter;
        }
    }

    class DataSave2                                                                              // рабочий класс
    {
        public static void Save()
        {
            List<ContactItem> list = ContactManager.ReturnList();

            XmlSerializer saver = new XmlSerializer(typeof(List<ContactItem>));
            FileStream fs = new FileStream("contactlist.xml", FileMode.Create);
            saver.Serialize(fs, list);
            fs.Close();
        }

        public static void Restore()
        {
            string xmlFile = @"contactlist.xml";

            if (File.Exists(xmlFile) == true)
            {
                XmlSerializer writer = new XmlSerializer(typeof(ContactItem[]));                   // почему-то не получается десериализовать в тип List<ContactItem>
                FileStream fs = new FileStream(xmlFile, FileMode.OpenOrCreate);
                ContactItem[] list = (ContactItem[])writer.Deserialize(fs);
                fs.Close();
                //ContactManager.UpdateContactList(list);
            }
            else
            {
                //ContactItem[] list = null;
                //ContactManager.UpdateContactList(list);
            }
        }
    }

    public class DataSave
    {
        public static void Save()
        {
            DataContainer mainContainer1 = new DataContainer();
            //mainContainer1.contactlist = ContactManager.ReturnList();
            //mainContainer1.notelist = NoteManager.ReturnListN();
            //mainContainer1.idx = ContactItem.idx_counter;

            XmlSerializer saver = new XmlSerializer(typeof(DataContainer));
            FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate);
            saver.Serialize(fs, mainContainer1);
            fs.Close();
        }

        public static void Restore()                                                             // не рабочий метод, сначала сделать метод Save 
        {
            string xmlFile = @"test.xml";

            if (File.Exists(xmlFile) == true)
            {
                XmlSerializer writer = new XmlSerializer(typeof(DataContainer));
                FileStream fs = new FileStream(xmlFile, FileMode.Open);
                DataContainer mainContainer = (DataContainer)writer.Deserialize(fs);
                fs.Close();
                ContactManager.UpdateContactList(mainContainer.contactlist);
                ContactItem.Update_Counter(mainContainer.idx);
            }
            //else
            //{
            //    ContactItem[] list = null;
            //    ContactManager.UpdateContactList(list);
            //}

        }
    }
}