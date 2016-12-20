using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public class BaseItem
    {
        public ValueType Searching (string str)
        {
            List<NoteItem> notes = NoteManager.Notelist;                //объявляются списки всех классов
            List<ContactItem> notes = ContactManager.Contactlist;       //
            foreach (NoteItem item in NoteManager)                      //далее перебираются все поля  и найденные контакты
                                                                        // и закладки добавляются в список items[] но это нифига не абстрактно...
            {

            }
            return  items[];
        }
    }
}
