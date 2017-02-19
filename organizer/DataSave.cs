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
            onRestore(ref dict);
            
        }
    }
}
