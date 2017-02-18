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
            list.AddRange(ContactManager.ReturnList());
            list.AddRange(NoteManager.ReturnListN());

            foreach (BaseItem item in list.ToArray())                              // Зачем здесь ToArray()? без него ругается на то, что коллекция была изменена и вываливается исключение
            {
                Console.WriteLine(item);
                if (item.GetType().ToString().Contains("ContactItem"))             //if (item.Equals(typeof(ContactItem)))  не работает
                {
                    ContactItem n_item = (ContactItem)item;
                    if (n_item.IsFound(stringToFind) == false)
                    {
                        list.Remove(item);
                        Console.WriteLine(n_item._name);
                    }
                }
                else
                {
                    if (item.GetType().ToString().Contains("NoteItem"))
                    {
                        NoteItem n_item = (NoteItem)item;
                        if (n_item.IsFound(stringToFind) == false)
                        {
                            list.Remove(item);
                            //Console.WriteLine(item.item_type);
                        }
                    }
                }
                
            }
            //foreach (NoteItem itemN in NoteManager.ReturnListN())
            //{
            //    if (itemN.IsFound(stringToFind) == true)
            //    {
            //        list.Add(itemN);
            //        //Console.WriteLine(itemN.item_type);
            //    }
            //}
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
                    ContactItem n_item = (ContactItem)item;
                    listBox1.Items.Add(n_item.ShortName());
                }
                else
                {
                    if (item.GetType().ToString().Contains("NoteItem"))
                    {
                        NoteItem n_item = (NoteItem)item;
                        listBox1.Items.Add(n_item.ShortName());
                    }
                }
                
                //if (item.GetType().ToString().Contains("ContactItem"))
                //{
                //    ContactItem cItem = (ContactItem)item;                            //   приведение типа работает для всех пследующих значений.......
                //    listBox1.Items.Add(cItem.GetType().ToString() + "\t" + cItem._name + "\t" + cItem._sername);
                //}
                //else
                //{
                //    if (item.GetType().ToString().Contains("NoteItem"))
                //    {
                //        NoteItem nItem = (NoteItem)item;
                //        listBox1.Items.Add(nItem.GetType().ToString() + "\t" + nItem.notename + "\t" + nItem.notetext);
                //        Console.WriteLine(nItem.item_type);
                //    }
                //}

                //listBox1.Items.Add(item.GetType());   //выводит правильные типы
            }
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}

