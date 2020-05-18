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
        private MedicalDataBase medicalDB;
        public Analysis(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
            medicalDB = new MedicalDataBase();
        }

        private void Analysis_Load(object sender, EventArgs e)
        {
            /*
            foreach(Control c in this.Controls)
            {
                if (c is RichTextBox) c.Text = "19";
            }
            */
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void addAnalysis_Click(object sender, EventArgs e)
        {
            if (checkCorrect())
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
                medicalDB.addAnalysToDatabase(analys, patient);
                List<Patient> l = new List<Patient>();
                l.Add(patient);
                medicalDB.writeToDatabase(l);
                if (owner != null)
                {
                    owner.changeLastSurvey();
                    owner.reload();
                }
                this.Close();
            }
            
        }

        private bool checkCorrect()
        {
            foreach(Control c in this.Controls)
            {
                if(c is RichTextBox)
                {
                    try
                    {
                        Convert.ToDouble(c.Text.Trim());
                        
                    }
                    catch
                    {
                        c.Text = "";
                        MessageBox.Show("Поля  заполнены некорректно.Попробуйте ещё раз");
                        return false;
                    }
                }
            }
            try
            {
                String[] b = maskedTextBox1.Text.Split('.');
                new DateTime(Convert.ToInt32(b[2]), Convert.ToInt32(b[1]), Convert.ToInt32(b[0]));
            }
            catch
            {
                maskedTextBox1.Clear();
                MessageBox.Show("Неверный формат даты последнего обследования.Попробуйте ещё раз");
                return false;
            }
            return true;
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == ',') return;
            else
                e.Handled = true;
        }
    }
}
