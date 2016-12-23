using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class NoteItem : BaseItem
    {
        public string NoteName;
        public string NoteText;

        public NoteItem (string NoteName, string NoteText)
        {
            this.NoteName = NoteName;
            this.NoteText = NoteText;
        }
    }
}
