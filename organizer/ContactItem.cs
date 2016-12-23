using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class ContactItem : BaseItem
    {
        public string Name;
        public string Sername;
        public string WebPage;
        public int Age;
        public int idx;
        static public int idx_counter = 0;

        public ContactItem()                                                        // пустой конструктор для сериализатора
        {
        }

        public ContactItem(string Name, string Sername, string WebPage, int Age, int idx)
        {
            this.Name = Name;
            this.Sername = Sername;
            this.WebPage = WebPage;
            this.Age = Age;
            this.idx = ++idx_counter;
        }

        public static void update_counter(int ridx_counter)
        {
            idx_counter = ridx_counter;
        }
    }
}
