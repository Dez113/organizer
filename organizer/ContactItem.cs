using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class ContactItem : BaseItem
    {
        public string _name;
        public string _sername;
        public string _webpage;
        public int _age;
        public int _idx;
        public iType item_type;
        public static int idx_counter = 0;

        static ContactItem()                                                                // пустой конструктор для сериализатора
        {
            DataSave.onSave += SaveIdx;
            //DataSave.onRestore += RestoreIdx;
        }

        public ContactItem(string name, string sername, string webpage, int age, int idx)
        {
            item_type = iType.contact;
            _name = name;
            _sername = sername;
            _webpage = webpage;
            _age = age;
            _idx = idx;
            idx_counter += 1;
        }

      
        //public static void Update_Counter(int read_idx_counter)
        //{
        //    idx_counter = read_idx_counter;
        //}

        public override bool IsFound(string str)
        {
            if (_name.Contains(str) || _sername.Contains(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SaveIdx(ref Dictionary<string, object> dict)
        {
            dict.Add("contact_idx", idx_counter);
        }

        public static void RestoreIdx(ref Dictionary<string, object> dict)
        {
            idx_counter = ((Newtonsoft.Json.Linq.JArray)dict["contact_idx"]).ToObject<int>();
        }

        public static void ReturnIdx()
        {
            
        }
    }
}
