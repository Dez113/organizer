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
                }
            }
            foreach (NoteItem itemN in NoteManager.ReturnListN())
            {
                if (itemN.IsFound(stringToFind) == true)
                {
                    list.Add(itemN);
                }
            }
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stringToFind = textBox1.Text;
            List<BaseItem> allFounded = Find(stringToFind);
            listBox1.Items.Clear();

            foreach (BaseItem item in allFounded)
            {
                listBox1.Items.Add(item.ToString());
            }
        }
    }
}

