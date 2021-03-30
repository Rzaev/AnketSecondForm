using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnketSecondForm
{
    public partial class Form1 : Form
    {
        string filename;
        int select = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var s = BirthdayTxt;

            listBox1.SelectionMode = SelectionMode.One;
            listBox1.DisplayMember = ToString();

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTxt.Text != string.Empty)
            {
                listBox1.Items.Add(new User
                {
                    Name = NameTxt.Text,
                    Surname = SurnameTxt.Text,
                    Email = EmailTxt.Text,
                    Phone = PhoneTxt.Text,
                    Birhday = BirthdayTxt.Value.ToString()
                });

                filename = NameTxt.Text;
            }
            else
            {
                MessageBox.Show("Name is empty!!!");
            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            select = listBox1.SelectedIndex;
            Files.JsonSerialize(listBox1.SelectedItem as User, filename);
            NameTxt.Text = "";
            SurnameTxt.Text = "";
            EmailTxt.Text = "";
            PhoneTxt.Text = string.Empty;
            BirthdayTxt.Text = string.Empty;

        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            string name = LoadTxt.Text;
            var ds = Files.JsonDeserialize(name);
            NameTxt.Text = ds.Name;
            SurnameTxt.Text = ds.Surname;
            EmailTxt.Text = ds.Email;
            PhoneTxt.Text = ds.Phone;
            BirthdayTxt.Text = ds.Birhday;

            AddBtn.Location = new Point(238, 381);
            AddBtn.Enabled = false;
            ChangeBtn.Location = new Point(238, 317);
            ChangeBtn.Enabled = true;

            NameTxt.Enabled = false;

        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            

            //ListBox.NoMatches != listBox1.FindStringExact(LoadTxt.Text);

           
            listBox1.Items.Add(new User
            {
                Name = NameTxt.Text,
                Surname = SurnameTxt.Text,
                Email = EmailTxt.Text,
                Phone = PhoneTxt.Text,
                Birhday = BirthdayTxt.Value.ToString()
            });

            // SaveBtn_Click(sender, e);
            Files.JsonSerialize(listBox1.SelectedItem as User, filename);
            NameTxt.Text = "";
            SurnameTxt.Text = "";
            EmailTxt.Text = "";
            PhoneTxt.Text = string.Empty;
            BirthdayTxt.Text = string.Empty;
            listBox1.Items.RemoveAt(select);

            //select = select + 1;
            //SaveBtn_Click(sender, e);
            //listBox1.Items.RemoveAt(select);
            NameTxt.Enabled = true;
            ChangeBtn.Location = new Point(238, 381);
            ChangeBtn.Enabled = false;
            AddBtn.Location = new Point(238, 317);
            AddBtn.Enabled = true;
        }
    }
}
