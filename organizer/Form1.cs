﻿using System;
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

        ContactManager manager = new ContactManager();

        private void listBox_update()//обновление листбокса после изменений в ContactManager.contactlist (после добавления/удаления контакта)
        {
            listBox1.Items.Clear();
            List<ContactItem> list = manager.ReturnContactList();
            foreach (ContactItem item in list)//прямое обращение к контактлисту, нужно изменить (изменено криво, смотреть ContactManager.ReturnContactList())
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
                ContactItem conn = new ContactItem(name, sername, webpage, age);
                //string mess = System.String.Format("{0},{1}",conn.personName, conn.personSername);
                //MessageBox.Show(mess);
                //ContactManager manager = new ContactManager(conn);
                manager.AddContact(conn);
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
            ContactItem ReturnedContact;
            ReturnedContact = manager.ReturnContactItemViaListBoxIndex(listboxIndex);
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
                manager.RemoveContact(listboxIndex);
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
            ContactItem ReturnedContact = null;
            //int itemindex = -3;
            if (stringToFind.Length != 0)
            {
                ReturnedContact = manager.ReturnFoundedContact(stringToFind);

                //foreach (ContactItem item in ContactManager.contactList)
                //{
                //    string line = item.personName + " \t" + item.personSername + " \t" + item.personAge + " \t" + item.personWebPage;
                //    if (line.Contains(stringToFind))
                //    {
                //        itemindex = ContactManager.contactList.IndexOf(item);
                //        break;
                //    }
                
                        
                    //foreach (typeof(ContactItem).GetField)
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
                    listBox1.SetSelected(manager.ReturnContactIndex(ReturnedContact), true);
                }
                

            }
        }
    }

