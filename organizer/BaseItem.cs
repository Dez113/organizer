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
        
        public virtual bool IsFound (string str)
        {
            return false;
        }
    }
}
