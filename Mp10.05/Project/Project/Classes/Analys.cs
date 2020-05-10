using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public class Analys
    {
        public DateTime lastSurvey { get; set; }

        public Analys(DateTime lastSurvey)
        {
            this.lastSurvey = lastSurvey;
        }
    }
}
