using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Classes;

namespace Project
{
    public partial class Report : Form
    {
        List<ReportElem> list;

        public Report(List<ReportElem> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (ReportElem elem in list)
            {                
                dataGridView1.Rows.Add(elem.name, Convert.ToString(elem.percentNormL +" - " +elem.percentNormR),elem.percentRes, Convert.ToString(elem.normL + " - " + elem.normR),elem.res);
                if (dataGridView1.Rows.Count == 1) dataGridView1.ClearSelection();
            }
        }
    }
}
