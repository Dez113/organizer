using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace organizer
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private List<BaseItem> Find (string stringToFind)
        {
            List<BaseItem> list = new List<BaseItem>();

            foreach (ContactItem item in ContactManager.ReturnList())
            {
                if (item.IsFound(stringToFind) == true)
                {
                    list.Add(item);
                    Console.WriteLine(item.item_type);
                }
            }
            foreach (NoteItem itemN in NoteManager.ReturnListN())
            {
                if (itemN.IsFound(stringToFind) == true)
                {
                    list.Add(itemN);
                    Console.WriteLine(itemN.item_type);
                }
            }
            return list;
        }

        private void button1_Click(object sender, EventArgs e)                          // поиск в контактах и заметках
        {
            string stringToFind = textBox1.Text;
            List<BaseItem> allFounded = Find(stringToFind);
            listBox1.Items.Clear();

            foreach (BaseItem item in allFounded)
            {
                if (item.GetType().ToString().Contains("ContactItem"))
                {
                    ContactItem cItem = (ContactItem)item;                            //   приведение типа работает для всех пследующих значений.......
                    listBox1.Items.Add(cItem.GetType().ToString() + "\t" + cItem._name + "\t" + cItem._sername);
                }
                else
                {
                    if (item.GetType().ToString().Contains("NoteItem"))
                    {
                        NoteItem nItem = (NoteItem)item;
                        listBox1.Items.Add(nItem.GetType().ToString() + "\t" + nItem.notename + "\t" + nItem.notetext);
                        Console.WriteLine(nItem.item_type);
                    }

                }

                //listBox1.Items.Add(item.GetType());   //выводит правильные типы
            }
        }
    }
}

