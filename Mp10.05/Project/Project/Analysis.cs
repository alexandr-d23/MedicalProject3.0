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
    public partial class Analysis : Form
    {
        public ProfileInfo owner;
        private Patient patient;
        public Analysis(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
            foreach(Control control in this.Controls)
            {
                control.Text = "19";
            }
        }

        private void Analysis_Load(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void addAnalysis_Click(object sender, EventArgs e)
        {
            String[] b = maskedTextBox1.Text.Split('.');
            DateTime lastSurvey = new DateTime(Convert.ToInt32(b[2]), Convert.ToInt32(b[1]), Convert.ToInt32(b[0]));
            Analys analys = new Analys(lastSurvey);
            foreach (Control control in this.Controls)
            {
                if (control is RichTextBox)
                {
                    analys.addTitles(Convert.ToString(control.Tag), Convert.ToDouble(control.Text));
                }
            }
            patient.addAnalys(analys);
            if (owner != null) owner.changeLastSurvey();
            this.Close();
        }

        private void richTextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox24_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
