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
            this.notename = NoteName;
            this.notetext = NoteText;
        }
    }
}
