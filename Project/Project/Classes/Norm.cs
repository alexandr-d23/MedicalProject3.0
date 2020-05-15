using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public class Norm
    {
        public string name { get; set; }
        public double percentNormL { get; set; }
        public double percentNormR { get; set; }
        public double normL { get; set; }
        public double normR { get; set; }

        public Norm(string name, double percentNormL, double percentNormR, double normL, double normR)
        {
            this.name = name;
            this.percentNormL = percentNormL;
            this.percentNormR = percentNormR;
            this.normL = normL;
            this.normR = normR;        
        }
    }
}
