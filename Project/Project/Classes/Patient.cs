using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public class Patient
    {
        public int PatientID { get; set; }
        public Information information { get; set; }
        public virtual IList<Analys> list { get; set; }

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
            analys.PatientID = this.PatientID;
            list.Add(analys);
            if (analys.lastSurvey > information.lastSurvey) information.lastSurvey = analys.lastSurvey;
        }

        public void changeLastSurvey() {
            information.lastSurvey =  new DateTime(1,1,1);
            foreach(Analys analys in list)
            {
                if (analys.lastSurvey > information.lastSurvey) information.lastSurvey = analys.lastSurvey;
            }
        }
    }
}
