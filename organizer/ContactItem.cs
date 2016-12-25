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
        public int idx;
        static public int idx_counter = 0;

        public ContactItem()                                                        // пустой конструктор для сериализатора
        {
        }

        public ContactItem(string name, string sername, string webpage, int age, int idx)
        {
            _name = name;
            _sername = sername;
            _webpage = webpage;
            _age = age;
            idx = ++idx_counter;
        }

        public static void Update_Counter(int ridx_counter)
        {
            idx_counter = ridx_counter;
        }

    }
}
