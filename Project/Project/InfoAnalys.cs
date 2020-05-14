using Project.Classes;
using System;
using System.Collections;
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
    public partial class InfoAnalys : Form
    {
        Patient patient;
        Analys analys;
        public InfoAnalys(Patient patient, Analys analys)
        {
            InitializeComponent();
            this.patient = patient;
            this.analys = analys;
            //List<string> title = new List<string>();
            //title.AddRange(Analys.titles.Keys);
            //listBox2.Items.AddRange(title);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                if(control is RichTextBox)
                {
                    if(!(control.Tag is null))
                    if (analys.titles.ContainsKey(control.Tag.ToString())){
                        control.Text = analys.titles[control.Tag.ToString()].ToString();
                    }
                }
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label21, "ни Т, ни В, ни NK-клетки");
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
