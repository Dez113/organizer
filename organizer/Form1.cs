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

        ContactManager manager = new ContactManager();

        private void listBox_update()//обновление листбокса после изменений в ContactManager.contactlist (после добавления/удаления контакта)
        {
            listBox1.Items.Clear();
            foreach (ContactItem item in ContactManager.contactList)//прямое обращение к контактлисту, нужно изменить
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
            //MessageBox.Show(listboxIndex.ToString());
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox5.Text=(ContactManager.contactList[listboxIndex].personName);//прямое обращение к контактлисту, нужно изменить
            textBox6.AppendText(ContactManager.contactList[listboxIndex].personSername);//прямое обращение к контактлисту, нужно изменить
            textBox7.AppendText(ContactManager.contactList[listboxIndex].personAge.ToString());//прямое обращение к контактлисту, нужно изменить
            textBox8.AppendText(ContactManager.contactList[listboxIndex].personWebPage);//прямое обращение к контактлисту, нужно изменить
        }

        private void button2_Click(object sender, EventArgs e)//удаление контакта
        {
            int listboxIndex = listBox1.SelectedIndex;// почему не удалось воспользоваться переменной из метода выше? как ее объявить уровнем выше?
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
            int itemindex = -3;
            if (stringToFind.Length != 0)
            {
                foreach (ContactItem item in ContactManager.contactList)
                {
                    string line = item.personName + " \t" + item.personSername + " \t" + item.personAge + " \t" + item.personWebPage;
                    if (line.Contains(stringToFind))
                    {
                        itemindex = ContactManager.contactList.IndexOf(item);
                        break;
                    }
                
                        
                    //foreach (typeof(ContactItem).GetField)
                }
                if (itemindex != -3)
                {
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox5.AppendText(ContactManager.contactList[itemindex].personName);
                    textBox6.AppendText(ContactManager.contactList[itemindex].personSername);
                    textBox7.AppendText(ContactManager.contactList[itemindex].personAge.ToString());
                    textBox8.AppendText(ContactManager.contactList[itemindex].personWebPage);
                    listBox1.SetSelected(itemindex, true);
                }
                

            }
        }
    }
}
