using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public class AnalysTitle {
        public int AnalysTitleID { get; set; }
        public int AnalysID { get; set; }
        public string key { get; set; }
        public double value { get; set; }

        public AnalysTitle(int AnalysID, string key, double value)
        {
            this.AnalysID = AnalysID;
            this.key = key;
            this.value = value;
        }
    }
}
