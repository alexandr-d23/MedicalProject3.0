using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public class Patient
    {
        Information information;
        private List<Analys> list;

        private Patient()
        {

        }

        public Patient(Information information)
        {
            this.information = information;
            list = new List<Analys>();
        }

        public Information getInformation()
        {
            return information;
        }

        public void addAnalys(Analys analys)
        {
            list.Add(analys);
            if (analys.lastSurvey > information.lastSurvey) information.lastSurvey = analys.lastSurvey;
        }
    }
}
