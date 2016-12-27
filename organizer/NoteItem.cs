using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class NoteItem : BaseItem
    {
        public string notename;
        public string notetext;
        public iType item_type;

        public NoteItem()
        {

        }
        public NoteItem (string NoteName, string NoteText)
        {
            iType item_type = iType.note;
            this.notename = NoteName;
            this.notetext = NoteText;
        }

        public override bool IsFound(string str)
        {
            if (notename.Contains(str))
            {
                return true;
            }
            return false;
            
        }
    }
}
