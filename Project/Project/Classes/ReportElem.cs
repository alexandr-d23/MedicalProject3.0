using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public class ReportElem
    {
        public string name { get; set; }
        public double percentNormL { get; set; }
        public double percentNormR { get; set; }
        public double percentRes { get; set; }
        public double normL { get; set; }
        public double normR { get; set; }
        public double res { get; set; }

        public ReportElem(string name, double percentNormL, double percentNormR, double percentRes, double normL, double normR, double res)
        {
            this.name = name;
            this.percentNormL = percentNormL;
            this.percentNormR = percentNormR;
            this.percentRes = percentRes;
            this.normL = normL;
            this.normR = normR;
            this.res = res;
        }
    }
}
