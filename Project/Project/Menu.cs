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
    public partial class Menu : Form
    {
        private List<Patient> list;
        private MedicalDataBase medicalDB;

        public Menu()
        {
            InitializeComponent();
            list = new List<Patient>();
            medicalDB = new MedicalDataBase();
            list = medicalDB.readFromDatabase();
        }

        public void addPatient(Patient p)
        {
            Information inf = (Information)p.getInformation();
            String lastS = inf.lastSurvey.ToShortDateString().Equals("01.01.0001") ? "-" : inf.lastSurvey.ToShortDateString();
            dataGridView1.Rows.Add(list.Count,inf.fName,inf.lName,inf.patronymic,inf.sitizenShip,inf.attachment,lastS);
            if(dataGridView1.Rows.Count==1)dataGridView1.ClearSelection();
            list.Add(p);
            medicalDB.writeToDatabase(list);
            /*
            var l= from inf in list select inf.getInformation();
            dataGridView1.DataSource = from inf in list select (Information)inf.getInformation();
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void addPatientButton_Click(object sender, EventArgs e)
        {
            Profile form1 = new Profile(this);
            form1.Show();
        }
        /* Profile form1 = new Profile(this);
            form1.Show();
            */

        private void PatientListButton_Click(object sender, EventArgs e)
        {
            reload();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   if (e.RowIndex < 0)
            {
                dataGridView1.ClearSelection();
                return;
            }
            ProfileInfo form = new ProfileInfo(list[Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)]);
            form.Show();
        }

        private void addAnalysButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }
            Analysis form = new Analysis(list[Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)]);
            form.Show();
            medicalDB.writeToDatabase(list);
        }

        public void reload()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            foreach(Patient p in list){
                Information inf = (Information)p.getInformation();
                String lastS = inf.lastSurvey.ToShortDateString().Equals("01.01.0001") ? "-" : inf.lastSurvey.ToShortDateString();
                dataGridView1.Rows.Add(i,inf.fName, inf.lName, inf.patronymic, inf.sitizenShip, inf.attachment, lastS);
                if (dataGridView1.Rows.Count == 1) dataGridView1.ClearSelection();
                i++;
            }

        }

        private void PatientListButton_Click_1(object sender, EventArgs e)
        {
            reload();
        }

       
        /*
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                addAnalysButton.Enabled = true;
                delete.Enabled = true;
                openProfile.Enabled = true;
            }
        }
        */

        /*
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                addAnalysButton.Enabled = false;
                delete.Enabled = false;
                openProfile.Enabled = false;
            }

        }
        */

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента для удаления");
                return;
            }
            DialogResult dr = MessageBox.Show("Вы уверены,что хотите удалить пациента?",
                      "Dialog", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    medicalDB.removePatient(list[Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)]);
                    list.RemoveAt(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    reload();
                    medicalDB.writeToDatabase(list);
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (richTextBox1.Text == String.Empty || richTextBox1.Text == "Имя Фамилия" && richTextBox1.ForeColor == Color.DarkGray)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
            else for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                    bool visible = false; ;
                    string[] arr = richTextBox1.Text.Trim().Split();
                    if(dataGridView1[1, i].Value.ToString().ToLower().StartsWith(arr[0].ToLower())){
                        if (arr.Length < 2) visible = true;
                        else if (dataGridView1[2, i].Value.ToString().ToLower().StartsWith(arr[1].ToLower())) visible = true;
                    }
                    if (visible) {
                        dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Visible = false;
                    }
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {   
            if (richTextBox1.Text == "Имя Фамилия" && richTextBox1.ForeColor == Color.DarkGray)
            {
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.Text = String.Empty;
            }
            
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if(richTextBox1.Text == String.Empty)
            {
                richTextBox1.ForeColor = Color.DarkGray;
                richTextBox1.Text = "Имя Фамилия";
            }
        }

        private void openProfile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }
            ProfileInfo form = new ProfileInfo(list[Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)]);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
    
}
