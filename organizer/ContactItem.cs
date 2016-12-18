using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class ContactItem
    {
        public string Name;
        public string Sername;
        public string WebPage;
        public int Age;

        public ContactItem()
        {

        }
        public ContactItem(string Name, string Sername, string WebPage, int Age)
        {
            this.Name = Name;
            this.Sername = Sername;
            this.WebPage = WebPage;
            this.Age = Age;
        }
    }
}
