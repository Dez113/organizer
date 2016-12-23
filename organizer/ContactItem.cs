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
        public int idx = 0;

        public ContactItem()                                                        // пустой конструктор для сериализатора
        {

        }

        public int idx_it(int idx)
        {
            return idx += 1;
        }

        public ContactItem(string Name, string Sername, string WebPage, int Age, int idx)
        {
            this.Name = Name;
            this.Sername = Sername;
            this.WebPage = WebPage;
            this.Age = Age;
            this.idx = idx_it(idx);
        }
        

       
    }
}
