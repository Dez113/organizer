using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    class NoteManager
    {
        static NoteManager()
        {
            DataSave.onSave += SaveNotes;
            DataSave.onRestore += RestoreNotes;
        }

        private static List<NoteItem> notelist = new List<NoteItem>();               //список заметок

        public static void AddNote(NoteItem item)                                   // добавлениие заметки
        {
            notelist.Add(item);
        }

        public static void RemoveNote(NoteItem item)                                //удаление заметки
        {
            notelist.Remove(item);
        }

        public static NoteItem ReturnNoteItemViaListBoxIndex(int index)             //возвращает элемент по индексу (выбранный элемент в листбоксе)
        {
            return (notelist[index]);
        }

        public static string[] ReturnNoteList()                                     //возвращает список всех элементов безопасно
        {
            int i = 0;
            string[] notes = new string[notelist.Count];

            foreach(NoteItem note in notelist)
            {
                notes[i] = note.notename + '\t' + note.notetext + '\t' + note.item_type;
                i++;
            }
            return notes;
        }

        public static NoteItem FoundedContact(string stringToFind)                  //возвращает первый найцденнный контакт
        {
            NoteItem toreturn = null;
            foreach (NoteItem item in notelist)
            {
                string line = item.notename + " \t" + item.notetext;
                if (line.Contains(stringToFind))
                {
                    toreturn = item;
                    break;
                }
            }
            return toreturn;
        }

        public static int ReturnContactIndex(NoteItem item)                         //возвращает порядковый номер в листе
        {
            return notelist.IndexOf(item);
        }

        public static List<NoteItem> ReturnListN()
        {
            return notelist;
        }

        public static void UpdateNoteList (List<NoteItem> list)
        {
            List<NoteItem> notelist = new List<NoteItem>(list);

        }

        public static void SaveNotes(ref Dictionary<string, object> dict)
        {
            dict.Add("notes", notelist);
        }

        public static void RestoreNotes (ref Dictionary<string, object> dict)
        {
            notelist = (List<NoteItem>)dict["notes"]; 
        }
    }
}
