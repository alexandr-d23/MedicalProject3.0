using Project.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Profile : Form
    {
        private Menu owner;
        Dictionary<string, bool> changes;

        public Profile(Menu owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            changes = new Dictionary<string, bool>();            
            textBox1.Text = "Ришат";
            textBox2.Text = "Ганиев";
            textBox3.Text = "Анасович";
            comboBox1.Text = "Мужской";
            maskedTextBox1.Text = "19.09.1993";
            textBox4.Text = "РФ";
            maskedTextBox2.Text = "1234-123456";
            maskedTextBox3.Text = "1234567890123456";
            textBox5.Text = "New";
        }


        private void Save_Click(object sender, EventArgs e)
        {

            try
            {
                string fName = textBox1.Text;
                string lName = textBox2.Text;
                string patronymic = textBox3.Text;
                Boolean gender = comboBox1.Text == "Мужской" ? true : false;
                String[] b = maskedTextBox1.Text.Split('.');
                DateTime birthday = new DateTime(Convert.ToInt32(b[2]), Convert.ToInt32(b[1]), Convert.ToInt32(b[0]));
                string sitizenShip = textBox4.Text;
                string passportData = maskedTextBox2.Text;
                string insurancePolicy = maskedTextBox3.Text;
                string attachment = textBox5.Text;
                Information inf = new Information(fName, lName, patronymic, gender, birthday, sitizenShip, passportData, insurancePolicy, attachment);
                owner.addPatient(new Patient(inf));
                this.Close();
            }
            catch
            {
                MessageBox.Show("Поля заполнены некорректно");
            }


        }


        /*
        private bool Check_Correct()
        {
            bool b = true;
            foreach (Control c in this.Controls) {
                if (c is TextBox && string.IsNullOrWhiteSpace(c.Text) || c is MaskedTextBox && !(c as MaskedTextBox).MaskCompleted)
                {
                    b = false;
                    MessageBox.Show("Заполните все поля");
                    break;
                }
                string[] s = maskedTextBox1.Text.Split('.');

                if (Convert.ToInt32(s[2])<1900 || 1>Convert.ToInt32(s[1]) || Convert.ToInt32(s[1])>12 || 1>Convert.ToInt32(s[0]) || Convert.ToInt32(s[0])> 31)
                {
                    b = false;
                    MessageBox.Show("Поле \"Дата рождения\" заполнено некорректно");
                    break;
                }

            }
            return b;
        }
        */

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                Change("text5", false);
                textBox5.BackColor = Color.OrangeRed;
            }
            else
            {
                Change("text5", true);
                textBox5.BackColor = Color.White;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Change("text1", false);
                textBox1.BackColor = Color.OrangeRed;
            }
            else
            {
                Change("text1", true);
                textBox1.BackColor = Color.White;
            }
        }

        private void Change(string key, bool val)
        {
            bool enabled = true;
            if (changes.ContainsKey(key))
            {
                changes[key] = val;
            }
            else changes.Add(key, val);
            if (changes.Count != 9)
            {
                enabled = false;
            }
            else foreach (KeyValuePair<string, bool> pair in changes) {
                    if (!pair.Value)
                    {
                        enabled = false;
                        break;
                    }
                }
            Save.Enabled = enabled;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Change("text2", false);
                textBox2.BackColor = Color.Red;
            }
            else
            {
                Change("text2", true);
                textBox2.BackColor = Color.White;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                Change("text3", false);
                textBox3.BackColor = Color.OrangeRed;
            }
            else
            {
                Change("text3", true);
                textBox3.BackColor = Color.White;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                Change("combo1", false);
                comboBox1.BackColor = Color.OrangeRed;
            }
            else
            {
                Change("combo1", true);
                comboBox1.BackColor = Color.White;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                Change("text4", false);
                textBox4.BackColor = Color.OrangeRed;
            }
            else
            {
                Change("text4", true);
                textBox4.BackColor = Color.White;
            }
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBox3.MaskCompleted)
            {
                Change("mtext3", false);
                maskedTextBox3.BackColor = Color.OrangeRed;
            }
            else
            {
                Change("mtext3", true);
                maskedTextBox3.BackColor = Color.White;
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBox2.MaskCompleted)
            {
                Change("mtext2", false);
                maskedTextBox2.BackColor = Color.OrangeRed;
            }
            else
            {
                Change("mtext2", true);
                maskedTextBox2.BackColor = Color.White;
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {           
            if (!maskedTextBox1.MaskCompleted)
            {
                Change("mtext1", false);
                maskedTextBox1.BackColor = Color.OrangeRed;
            }
            else{
                string[] s = maskedTextBox1.Text.Split('.');
                if (Convert.ToInt32(s[2]) >= 1900 && 1 <= Convert.ToInt32(s[1]) && Convert.ToInt32(s[1]) <= 12 && 1 <= Convert.ToInt32(s[0]) && Convert.ToInt32(s[0]) <= 31)
                {
                    Change("mtext1", true);
                    maskedTextBox1.BackColor = Color.White;
                }
                else
                {
                    Change("mtext1", false);
                    maskedTextBox1.BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
