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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void listBox_update()//обновление листбокса после изменений в ContactManager.contactlist (после добавления/удаления контакта)
        {
            listBox1.Items.Clear();
            List<NoteItem> list = ContactManager.ReturnContactList();
            foreach (NoteItem item in list)//прямое обращение к контактлисту, нужно изменить (изменено криво, смотреть ContactManager.ReturnContactList())
            {
                string line = item.personName + " \t" + item.personSername + " \t" + item.personAge + " \t" + item.personWebPage;
                listBox1.Items.Add(line);
            }
        }

        void listbox_selectedIndex(object sender, EventArgs e)//выбранный элемент в листбоксе
        {
            int listboxIndex = listBox1.SelectedIndex;
            MessageBox.Show(listboxIndex.ToString());

        }

        private void button1_Click(object sender, EventArgs e)//добавление контакта
        {
            string name, sername, webpage;
            int age;
            name = textBox1.Text;
            sername = textBox2.Text;
            webpage = textBox4.Text;
            int.TryParse(textBox3.Text, out age);
            if (name.Length == 0 || sername.Length == 0)
            {
                MessageBox.Show("Имя и фамилия не должны быть пустыми");
            }
            else
            {
                NoteItem conn = new NoteItem(name, sername, webpage, age);
                ContactManager.AddContact(conn);
                listBox_update();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox3.Text= "0";
                textBox4.Clear();

            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)// замена информации о выбранном контакте в групбокс2
        {
            int listboxIndex = listBox1.SelectedIndex;
            NoteItem ReturnedContact;
            ReturnedContact = ContactManager.ReturnContactItemViaListBoxIndex(listboxIndex);
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox5.Text=(ReturnedContact.personName);
            textBox6.Text=(ReturnedContact.personSername);
            textBox7.Text=(ReturnedContact.personAge.ToString());
            textBox8.Text=(ReturnedContact.personWebPage);
        }

        private void button2_Click(object sender, EventArgs e)//удаление контакта
        {
            int listboxIndex = listBox1.SelectedIndex;
            if (listboxIndex != -1)
            {
                ContactManager.RemoveContact(listboxIndex);
                listBox_update();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)//поиск элемента
        {
            string stringToFind = textBox9.Text;
            NoteItem ReturnedContact = null;
            if (stringToFind.Length != 0)
            {
                ReturnedContact = ContactManager.ReturnFoundedContact(stringToFind);
                }
                if (ReturnedContact != null)
            {
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox5.Text=(ReturnedContact.personName);
                    textBox6.Text = (ReturnedContact.personSername);
                    textBox7.Text = (ReturnedContact.personAge.ToString());
                    textBox8.Text=(ReturnedContact.personWebPage);
                listBox1.SetSelected(ContactManager.ReturnContactIndex(ReturnedContact), true);
                }
            }
        /// <summary>
        /// Addittion new bookmark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string Name = textBox13.Text;
            string Text = textBox12.Text;


        }
    }
    }

