using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    class MedicalDataBase
    {
        public MedicalDataBase()
        {

        }

        public List<Patient> readFromDatabase()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Patient> list = new List<Patient>();
                List<Analys> aList = new List<Analys>();
                aList = db.Analysis.Include(p => p.analysTitles).ToList();
                list = db.Patients.Include(p => p.information).Include(p => p.list).ToList();
                foreach (Patient patient in list)
                {
                    foreach (Analys analys in patient.list)
                    {
                        analys.convertICollectionToDictionary();
                    }
                }
                return list;
            }
        }

        public void writeToDatabase(List<Patient> list)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (Patient patient in list)
                {
                    foreach (Analys analys in patient.list)
                    {
                        analys.convertDictionaryToICollection();
                        db.Update(analys);
                    }
                    db.Update(patient);
                }
                db.SaveChanges();
            }
        }

        public void addAnalysToDatabase(Analys analys, Patient patient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                analys.PatientID = patient.PatientID;
                analys.convertDictionaryToICollection();
                db.Add(analys);
                db.SaveChanges();
            }
        }

        public void removePatient(Patient p)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Patient patient = db.Patients.Where(c => c.PatientID == p.PatientID).FirstOrDefault(); 
                db.Entry(patient).Collection(c => c.list).Load();
                foreach (Analys a in patient.list)
                {
                    Analys analys = db.Analysis.Where(c => c.AnalysID == a.AnalysID).FirstOrDefault();
                    db.Entry(analys).Collection(c => c.analysTitles).Load();
                    db.Analysis.Remove(analys);
                }
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
        }

        public void removeAnalys(Analys a)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Analys analys = db.Analysis.Where(c => c.AnalysID == a.AnalysID).FirstOrDefault();
                db.Entry(analys).Collection(c => c.analysTitles).Load();
                db.Analysis.Remove(analys);
                db.SaveChanges();
            }
        }
    }
}
