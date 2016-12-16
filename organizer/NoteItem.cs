using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class NoteItem
    {
        public string bookmarkName;
        public string bookmarkText;


        public NoteItem (string bookmarkName, string bookmarkText)
        {
            this.bookmarkName = bookmarkName;
            this.bookmarkText = bookmarkText;
        }
    }
}
