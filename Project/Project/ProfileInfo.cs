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
    public partial class ProfileInfo : Form
    {
        Information info;
        Patient patient;
        Dictionary<string, bool> changes;
        public ProfileInfo(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
        }

        private void ProfileInfo_Load(object sender, EventArgs e)
        {
            changes = new Dictionary<string, bool>();
            info = patient.getInformation();
            textBox1.Text = info.fName;
            textBox2.Text = info.lName;
            textBox3.Text = info.patronymic;
            comboBox1.Text = info.gender ? "Мужской" : "Женский";
            maskedTextBox1.Text = info.birthday.ToShortDateString();
            textBox4.Text = info.sitizenShip;
            maskedTextBox2.Text = info.passportData;
            maskedTextBox3.Text = info.insurancePolicy;
            textBox5.Text = info.attachment;
            maskedTextBox4.Text = info.lastSurvey.ToShortDateString().Equals("01.01.0001") ? "-" : info.lastSurvey.ToShortDateString();
            changes.Clear();
            save.Enabled = false;
        }

        private void addAnalysButton_Click(object sender, EventArgs e)
        {
            Analysis form = new Analysis(patient);
            form.owner = this;
            form.Show();
        }

        public void changeLastSurvey()
        {
            if (maskedTextBox4.Text != patient.getInformation().lastSurvey.ToShortDateString()) maskedTextBox4.Text = patient.getInformation().lastSurvey.ToShortDateString();
        }

        private void show_Click(object sender, EventArgs e)
        {   if (show.Text == "показать")
            {
                Captcha form = new Captcha(this);
                form.Show();
            }
            else
            {
                show.Text = "показать";
                richTextBox1.Visible = true;
                maskedTextBox2.Visible = false;
            }
        }

        public void passportDataShow()
        {
            richTextBox1.Visible = false;
            maskedTextBox2.Visible = true;
            show.Text = "скрыть";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Information info = patient.getInformation();
            try
            {
                info.fName = textBox1.Text;
                info.lName = textBox2.Text;
                info.patronymic = textBox3.Text;
                info.gender = comboBox1.Text == "Мужской" ? true : false;
                String[] b = maskedTextBox1.Text.Split('.');
                info.birthday = new DateTime(Convert.ToInt32(b[2]), Convert.ToInt32(b[1]), Convert.ToInt32(b[0]));
                info.sitizenShip = textBox4.Text;
                info.passportData = maskedTextBox2.Text;
                info.insurancePolicy = maskedTextBox3.Text;
                info.attachment = textBox5.Text;
                if (maskedTextBox4.Text != "  .  .")
                {
                    b = maskedTextBox4.Text.Split('.');
                    info.lastSurvey = new DateTime(Convert.ToInt32(b[2]), Convert.ToInt32(b[1]), Convert.ToInt32(b[0]));
                }
                changes.Clear();
                save.Enabled = false;
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
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && string.IsNullOrWhiteSpace(c.Text) || c is MaskedTextBox && !(c as MaskedTextBox).MaskCompleted)
                {
                    b = false;
                    MessageBox.Show("Заполните все поля");
                    break;
                }
                string[] s = maskedTextBox1.Text.Split('.');

                if (Convert.ToInt32(s[2]) < 1900 || 1 > Convert.ToInt32(s[1]) || Convert.ToInt32(s[1]) > 12 || 1 > Convert.ToInt32(s[0]) || Convert.ToInt32(s[0]) > 31)
                {
                    b = false;
                    MessageBox.Show("Поле \"Дата рождения\" заполнено некорректно");
                    break;
                }

            }
            return b;
        }
        */

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.BackColor = Color.OrangeRed;
                Change("text1", false);
            }
            else
            {
                textBox1.BackColor = Color.White;
                if(textBox1.Text != info.fName)
                {
                    Change("text1", true);
                }
                else
                {
                    Change("text1", false);
                }
            } 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.BackColor = Color.OrangeRed;
                Change("text2", false);
            }
            else
            {
                textBox2.BackColor = Color.White;
                if (textBox2.Text != info.lName)
                {
                    Change("text2", true);
                }
                else
                {
                    Change("text2", false);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.BackColor = Color.OrangeRed;
                Change("text3", false);
            }
            else
            {
                textBox3.BackColor = Color.White;
                if (textBox3.Text != info.patronymic)
                {
                    Change("text3", true);
                }
                else
                {
                    Change("text3", false);
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string s;
            if (info.gender == true)
            {
                s = "Мужской";
            }
            else s = "Женский";
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.BackColor = Color.OrangeRed;
                Change("combo1", false);
            }
            else
            {
                comboBox1.BackColor = Color.White;
                if (comboBox1.Text != s)
                {
                    Change("combo1", true);
                }
                else
                {
                    Change("combo1", false);
                }
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBox1.MaskCompleted)
            {
                maskedTextBox1.BackColor = Color.OrangeRed;
                Change("mtext1", false);
            }
            else
            {
                string[] s = maskedTextBox1.Text.Split('.');
                if (Convert.ToInt32(s[2]) >= 1900 && 1 <= Convert.ToInt32(s[1]) && Convert.ToInt32(s[1]) <= 12 && 1 <= Convert.ToInt32(s[0]) && Convert.ToInt32(s[0]) <= 31)
                {
                    maskedTextBox1.BackColor = Color.White;
                    DateTime birth = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
                    if (birth.Equals(info.birthday))
                    {
                        Change("mtext1", true);
                    }
                    else
                    {
                        Change("mtext1", false);
                    }
                }
                else
                {
                    Change("mtext1", false);
                    maskedTextBox1.BackColor = Color.OrangeRed;
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.BackColor = Color.OrangeRed;
                Change("text4", false);
            }
            else
            {
                textBox4.BackColor = Color.White;
                if (textBox4.Text != info.sitizenShip)
                {
                    Change("text4", true);
                }
                else
                {
                    Change("text4", false);
                }
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {

            if (!maskedTextBox2.MaskCompleted)
            {
                maskedTextBox2.BackColor = Color.OrangeRed;
                Change("mtext2", false);
            }
            else
            {
                maskedTextBox2.BackColor = Color.White;
                if (maskedTextBox2.Text != info.passportData)
                {
                    Change("mtext2", true);
                }
                else
                {
                    Change("mtext2", false);
                }

            }
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBox3.MaskCompleted)
            {
                maskedTextBox3.BackColor = Color.OrangeRed;
                Change("mtext3", false);
            }
            else
            {
                maskedTextBox3.BackColor = Color.White;
                if (maskedTextBox3.Text != info.insurancePolicy)
                {
                    Change("mtext3", true);
                }
                else
                {
                    Change("mtext3", false);
                }

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox5.BackColor = Color.OrangeRed;
                Change("text5", false);
                
            }
            else
            {
                textBox5.BackColor = Color.White;
                if (textBox5.Text != info.attachment)
                {
                    Change("text5", true);
                }
                else
                {
                    Change("text5", false);
                }
            }
        }

        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox4.Text == "  .  .")
            {
                maskedTextBox4.BackColor = Color.White;
                if (info.lastSurvey.ToShortDateString().Equals("01.01.0001"))
                {
                    Change("mtext4", false);
                }
                else
                {
                    Change("mtext4", true);
                }
            }
            else if (!maskedTextBox4.MaskCompleted)
            {
                maskedTextBox4.BackColor = Color.OrangeRed;
                Change("mtext4", false);               
            }
            else
            {   
                string[] s = maskedTextBox4.Text.Split('.');
                if (Convert.ToInt32(s[2]) >= 1900 && 1 <= Convert.ToInt32(s[1]) && Convert.ToInt32(s[1]) <= 12 && 1 <= Convert.ToInt32(s[0]) && Convert.ToInt32(s[0]) <= 31)
                {
                    maskedTextBox4.BackColor = Color.White;
                    DateTime birth = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
                    if (!birth.Equals(info.lastSurvey))
                    {
                        Change("mtext4", true);
                    }
                    else
                    {
                        Change("mtext4", false);
                    }
                }
                else
                {
                    Change("mtext4", false);
                    maskedTextBox4.BackColor = Color.OrangeRed;
                }
            }
        }

        private void Change(string key, bool val)
        {
            bool enabled = false;
            if (changes.ContainsKey(key))
            {
                changes[key] = val;
            }
            else changes.Add(key, val);
            foreach (KeyValuePair<string, bool> pair in changes)
            {
                if (pair.Value)
                {
                    enabled = true;
                    break;
                }
            }
            foreach (Control c in this.Controls)
            {
                if (c.BackColor == Color.OrangeRed) {
                    enabled = false;
                    break;
                }        
            }
            save.Enabled = enabled;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnalysInfo_Click(object sender, EventArgs e)
        {
            InfoAnalys info = new InfoAnalys(patient,patient.list[0]);
            info.Show();

        }
    }
}
