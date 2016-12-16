using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class ContactItem
    {
        public string personName;
        public string personSername;
        public string personWebPage;
        public int personAge;

        public ContactItem(string personName, string personSername, string personWebPage, int personAge)
        {
            this.personName = personName;
            this.personSername = personSername;
            this.personWebPage = personWebPage;
            this.personAge = personAge;
        }
    }
}
