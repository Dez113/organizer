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

            foreach (BaseItem item in list.ToArray())                              // потому что лист уменьшается, а этого делать нельзя
            {
                Console.WriteLine(item);
                if (item.GetType().ToString().Contains("ContactItem"))             //if (item.Equals(typeof(ContactItem)))  не работает
                {
                    if (!item.IsFound(stringToFind))
                    {
                        list.Remove(item);
                        //Console.WriteLine(n_item._name);
                    }
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
                listBox1.Items.Add(item.ShortName() + "\t" + item.item_type);
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

