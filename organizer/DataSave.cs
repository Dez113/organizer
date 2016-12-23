using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace organizer
{
    class DataContainer : System.ComponentModel.Container
    {
        public DataContainer()
        {

        }

        List<object> mainContainer = new List<object>();
        
        
    }

    class DataSave2
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
                XmlSerializer writer = new XmlSerializer(typeof(ContactItem[]));
                FileStream fs = new FileStream(xmlFile, FileMode.OpenOrCreate);
                ContactItem[] list = (ContactItem[])writer.Deserialize(fs);
                fs.Close();
                ContactManager.UpdateContactList(list);
            }
            else
            {
                ContactItem[] list = null;
                ContactManager.UpdateContactList(list);
            }
        }
    }

    class DataSave
    {
        public static void Save()
        {
            List<object> mainContainer = new List<object>();
            mainContainer.Add(ContactManager.ReturnList());
            mainContainer.Add(ContactItem.idx_counter);

            XmlSerializer saver = new XmlSerializer(typeof(List<Object>));
            FileStream fs = new FileStream("test.xml", FileMode.Create);
            saver.Serialize(fs, mainContainer);
            fs.Close();
        }

        //public static void Restore()
        //{
        //    string xmlFile = @"test.xml";

        //    if (File.Exists(xmlFile) == true)
        //    {
        //        XmlSerializer writer = new XmlSerializer(typeof(ContactItem[]));
        //        FileStream fs = new FileStream(xmlFile, FileMode.OpenOrCreate);
        //        List<object> list = (List<object>)writer.Deserialize(fs);
        //        fs.Close();
        //        ContactManager.UpdateContactList(list[0]);
        //    }
        //    else
        //    {
        //        ContactItem[] list = null;
        //        ContactManager.UpdateContactList(list);
        //    }

        //}
    }
}