using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

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
        public delegate void DataSaving(ref Dictionary<string, object> dict);
        public delegate void DataRestoring(ref Dictionary<string, object> dict);
        public static DataSaving onSave;
        public static DataSaving onRestore;

        public static void Save()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            onSave(ref dict);
            //ContactManager cm = new ContactManager();
            //NoteManager nm = new NoteManager();
            //ContactItem ci = new ContactItem();

            //XmlSerializer saver = new XmlSerializer(typeof(Dictionary<string, object>));
            //FileStream fs = new FileStream("test1.xml", FileMode.Create);
            //saver.Serialize(fs, dict);
            //fs.Close();

            string json = JsonConvert.SerializeObject(dict);
            byte[] save_data = Encoding.UTF8.GetBytes(json);
            FileStream fs1 = new FileStream("saves.json", FileMode.Create);
            fs1.Write(save_data, 0, save_data.Length);
            fs1.Close();
        }
        public static void Restore()
        {
            StreamReader fs = new StreamReader("saves.json");
            string json = fs.ReadToEnd();
            fs.Close();
            Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.Linq.JObject.Parse(json);
            //Console.WriteLine(obj);
            Dictionary<string, object> dict = obj.ToObject<Dictionary<string, object>>();
            Console.WriteLine(dict["contacts"]);
            //Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>((string)obj);
            //Console.WriteLine(dict);

            ContactManager cm = new ContactManager();            //восстановление все равно не работает,
            NoteManager nm = new NoteManager();                  // словарь отдается новым экземплярам классов?   
            onRestore(ref dict);
            
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
