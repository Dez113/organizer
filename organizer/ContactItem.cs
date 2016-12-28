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

        public ContactItem()                                                        // пустой конструктор для сериализатора
        {
        }

        public ContactItem(string name, string sername, string webpage, int age, int idx)
        {
            iType item_type = iType.contact;
            _name = name;
            _sername = sername;
            _webpage = webpage;
            _age = age;
            _idx = idx;
            idx_counter += 1;
        }

      
        public static void Update_Counter(int read_idx_counter)
        {
            idx_counter = read_idx_counter;
        }

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

        public static void SaveIdx()
        {
            DataContainer.dict.Add("contact_idx", idx_counter);
        }
    }
}
