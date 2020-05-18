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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
            
        }

        public void init()
        {
            maskedTextBox1.Text = patient.getInformation().lastSurvey.ToShortDateString().Equals("01.01.0001") ? "-" : patient.getInformation().lastSurvey.ToShortDateString();
            foreach (Control control in this.Controls)
            {
                if (control is RichTextBox)
                {
                    if (!(control.Tag is null))
                        if (analys.titles.ContainsKey(control.Tag.ToString()))
                        {
                            control.Text = analys.titles[control.Tag.ToString()].ToString();
                        }
                }
            }
            foreach (Control control in groupBox1.Controls)
            {

                if (analys.titles.ContainsKey(control.Tag.ToString()))
                {
                    control.Text = analys.titles[control.Tag.ToString()].ToString();
                }

            }

            double consta = Convert.ToDouble(richTextBox14.Text) * Convert.ToDouble(richTextBox54.Text) / 100;
            richTextBox26.Text = consta.ToString();
            foreach (Control control in groupBox2.Controls)
            {
                control.Text = (Val(control.Tag.ToString()) * consta / 100).ToString();
            }
        }

        public double Val(string str)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (str.Equals(c.Tag.ToString()))
                {
                    return Convert.ToDouble(c.Text);
                }
            }
            return 0;
        }

        public double Val2(string str)
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (str.Equals(c.Tag.ToString()))
                {
                    return Convert.ToDouble(c.Text);
                }
            }
            return 0;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label21, "ни Т, ни В, ни NK-клетки");
        }

        private void addAnalysis_Click(object sender, EventArgs e)
        {
            Report form = new Report(dataReport());
            form.Show();
        }


        public List<ReportElem> dataReport()
        {
            double patientRes;
            List<Norm> list = new List<Norm>()
            {
                new Norm("CD3+CD-19(Тл)",62,80,744,2640),
                new Norm("CD3-CD19+(Вл)", 6, 15, 72, 495),
                new Norm("CD3+CD4+(Th)", 35, 50, 420, 1650),
                new Norm("CD3+CD8+(Tc)", 18, 38, 216, 1254),
                new Norm("CD3-CD8+", 0, 5, 0, 160),
                new Norm("CD4+CD8+", 0, 2, 0, 24),
                new Norm("CD3+DR+", 3.5, 12, 42, 396),
                new Norm("CD3+DR-", 58.5, 65, 702, 2145),
                new Norm("CD8+DR+", 3, 8, 36, 264),
                new Norm("3-16+56+(NK)", 5, 15, 60, 465),
                new Norm("3+16+56+(NK-T)", 0, 5, 0, 60),
                new Norm("CD19+CD5+", 1, 2.5, 12, 82),
                new Norm("CD19+CD5-", 5, 12.5, 60, 412),
                new Norm("CD25+CD4+(спонт)", 5, 10, 60, 330),
                new Norm("CD3+CD4-CD8-y^σ", 0.1, 12.62, 0.1, 273),
                new Norm("Общие лимфоциты", 20, 40, 1200, 3300),
            };

            List<ReportElem> resList = new List<ReportElem>();
            foreach(Norm norm in list)
            {
                patientRes = Val(norm.name);
                if (patientRes < norm.percentNormL - double.Epsilon || patientRes > norm.percentNormR - double.Epsilon)
                {
                    resList.Add(new ReportElem(norm.name, norm.percentNormL, norm.percentNormR, patientRes, norm.normL, norm.normR, Val2(norm.name)));
                }
            }

            return resList;
        }
    }
}
