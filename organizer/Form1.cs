using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static organizer.DataSave;

namespace organizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
           
        }



//-----------------------------------------------------------------------------------------Contacts--------------------------------------------------------------------------------//


        private void UpdateContactListBox()                                                    //обновление листбокса после изменений в ContactManager.contactlist (после добавления/удаления контакта)
        {
            listBox1.Items.Clear();
            listView1.Items.Clear();
            string[] list = ContactManager.ReturnContactList();
            List<ContactItem> contacts = ContactManager.ReturnList();

            foreach (string line in list)
            {
                System.Console.WriteLine(line);
                listBox1.Items.Add(line);

                
            }
            foreach (ContactItem contact in contacts)
            {
                string[] row = { contact._name, contact._sername, contact._age.ToString(), contact._webpage };
                var ListViewitem = new ListViewItem ( row );
                listView1.Items.Add(ListViewitem);
            }


        }

        private void button1_Click(object sender, EventArgs e)                           //добавление контакта
        {
            string name = textBox1.Text;
            string sername = textBox2.Text;
            string webpage = textBox4.Text;
            int age;
            int.TryParse(textBox3.Text, out age);
            int idx = ContactItem.idx_counter;


            if (name.Length == 0 || sername.Length == 0)                                 //проверка на пустой ввод
            {
                MessageBox.Show("Имя и фамилия не должны быть пустыми");
            }
            else
            {
                ContactItem conn = new ContactItem(name, sername, webpage, age, idx);
                ContactManager.AddContact(conn);
                UpdateContactListBox();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)            // замена информации о выбранном контакте в групбокс2
        {
            int listboxIndex = listBox1.SelectedIndex;
            if (listboxIndex != -1)
            {
                ContactItem ReturnedContact = ContactManager.ReturnContactItemViaListBoxIndex(listboxIndex);
                textBox5.Text = ReturnedContact._name;
                textBox6.Text = ReturnedContact._sername;
                textBox7.Text = ReturnedContact._age.ToString();
                textBox8.Text = ReturnedContact._webpage;
            }
        }

        private void button2_Click(object sender, EventArgs e)                           //удаление контакта
        {
            int listboxIndex = listBox1.SelectedIndex;

            if (listboxIndex != -1)
            {
                ContactManager.RemoveContact(ContactManager.ReturnContactItemViaListBoxIndex(listboxIndex));
                UpdateContactListBox();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)                          //поиск элемента
        {
            string stringToFind = textBox9.Text;
            ContactItem ReturnedContact = null;

            if (stringToFind.Length != 0)
            {
                ReturnedContact = ContactManager.FoundedContact(stringToFind);
                }
                if (ReturnedContact != null)
            {
                textBox5.Text = ReturnedContact._name;
                textBox6.Text = ReturnedContact._sername;
                textBox7.Text = ReturnedContact._age.ToString();
                textBox8.Text = ReturnedContact._webpage;
                listBox1.SetSelected(ContactManager.ReturnContactIndex(ReturnedContact), true);
                }
            }

        

        //--------------------------------------------------------------------------------Notes--------------------------------------------------------------------------------//


        private void UpdateNoteList()                                                   //обновление листбокса заметок
        {
            listBox2.Items.Clear();
            string[] notes = NoteManager.ReturnNoteList();
            foreach(string line in notes)
            {
                listBox2.Items.Add(line);
            }
        }

        /// <summary>
        /// Addittion new bookmark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)                         //добавление заметки
        {
            string Name = textBox13.Text;
            string Text = textBox12.Text;
            if (Name.Length != 0)
            {
                NoteItem item = new NoteItem(Name, Text);

                NoteManager.AddNote(item);
                UpdateNoteList();
                textBox13.Clear();
                textBox12.Clear();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)          //обновление заметки в групбоксе
        {
            int lstbox2index = listBox2.SelectedIndex;
            if (lstbox2index != -1)
            {
                NoteItem bkmark = NoteManager.ReturnNoteItemViaListBoxIndex(lstbox2index);

                textBox11.Text = bkmark.notename;
                textBox10.Text = bkmark.notetext;
            }
        }

        private void button5_Click(object sender, EventArgs e)                          //удаление заметки
        {
            int listbox2index = listBox2.SelectedIndex;

            if (listbox2index != -1)
            {
                NoteManager.RemoveNote(NoteManager.ReturnNoteItemViaListBoxIndex(listbox2index));
                UpdateNoteList();
                textBox10.Clear();
                textBox11.Clear();
            }
        }

        
        //------------------------------------------------------------------------------Serialize-------------------------------------------------------------------------//

        private void MainForm_Load(object sender, EventArgs e)                          // чтение данных из файла при открытии формы
        {
            //DataSave.Restore();                                                       
            //UpdateContactListBox();
            //UpdateNoteList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)        //сохранение данных при закрытии
        {
            Save();
            
        }

        private void seatchF3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm SearchForm = new SearchForm();
            SearchForm.Show();
        }
    }
}

