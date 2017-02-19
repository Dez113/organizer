using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public enum iType
    {
        contact,
        note,
        unsigned
    }

    public class BaseItem
    {
        public int idx;
        public iType item_type;
        public virtual bool IsFound (string str)
        {
            return false;
        }

        public virtual string ShortName()
        {
            return "ShortName";
        }
    }
}
