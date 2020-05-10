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
            patient.addAnalys(new Analys(lastSurvey));
            if (owner != null) owner.changeLastSurvey();
            this.Close();
        }
    }
}
