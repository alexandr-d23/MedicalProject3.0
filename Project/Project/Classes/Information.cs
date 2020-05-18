using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public class Information  
    {
        public int InformationID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string patronymic { get; set; }
        public Boolean gender { get; set; }
        public DateTime birthday { get; set; }
        public string sitizenShip { get; set; }
        public string passportData { get; set; }
        public string insurancePolicy { get; set; }
        public string attachment { get; set; }
        public DateTime lastSurvey { get; set; }

        private Information()
        {

        }

        public Information(string fName, string lName, string patronymic, Boolean gender, DateTime birthday, string sitizenShip, string passportData, string insurancePolicy, string attachment)
        {
            this.fName = fName;
            this.lName = lName;
            this.patronymic = patronymic;
            this.gender = gender;
            this.birthday = birthday;
            this.sitizenShip = sitizenShip;
            this.passportData = passportData;
            this.insurancePolicy = insurancePolicy;
            this.attachment = attachment;
        }

    }
}
