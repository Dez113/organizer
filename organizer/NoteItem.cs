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

        public NoteItem()
        {

        }
        public NoteItem (string NoteName, string NoteText)
        {
            item_type = iType.note;
            this.notename = NoteName;
            this.notetext = NoteText;
        }

        public override bool IsFound(string str)
        {
            if (notename.Contains(str)|| notetext.Contains(str))
            {
                return true;
            }
            return false;
        }

        public override string ShortName()
        {
            NoteItem n_item = this;

            if (n_item.notetext.Length > 6)
            {
                string resault = n_item.notename + " " + n_item.notetext.Substring(0, 6);
                return resault;
            }
            else
            {
                string resault = n_item.notename + " " + n_item.notetext;
                return resault;
            }
            
        }
    }
}
