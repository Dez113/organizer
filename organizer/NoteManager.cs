using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    class NoteManager
    {
        public NoteManager()
        {

        }

        private NoteItem item;

        private static List<NoteItem> bookmarklist = new List<NoteItem>();

        public static void AddBookmark(NoteItem item)
        {
            bookmarklist.Add(item);

        }

        public static void RemoveBookmark(int index)
        {
            bookmarklist.RemoveAt(index);
        }

        public static NoteItem ReturnNoteItemViaListBoxIndex(int index)
        {
            return (bookmarklist[index]);
        }

        public static List<NoteItem> ReturnNoteList()
        {
            return bookmarklist;// скорее всего так нельзя (возвращается приватный контактлист)
        }

        public static NoteItem ReturnFoundedContact(string stringToFind)
        {
            NoteItem toreturn = null;
            foreach (NoteItem item in bookmarklist)
            {
                string line = item.bookmarkName + " \t" + item.bookmarkText;
                if (line.Contains(stringToFind))
                {
                    toreturn = item;
                    break;
                }
            }

            return toreturn;
        }

        public static int ReturnContactIndex(NoteItem item)
        {
            return bookmarklist.IndexOf(item);
        }
    }
}
