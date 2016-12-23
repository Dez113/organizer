using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace organizer
{
    class DataSave
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
}