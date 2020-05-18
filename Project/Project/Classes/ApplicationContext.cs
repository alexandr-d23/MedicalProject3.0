using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Classes
{
    class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Analys> Analysis { get; set; }
        public DbSet<AnalysTitle> AnalysTitles { get; set; }

        public ApplicationContext()
        {

          Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=medicaldb;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = master; Trusted_Connection = True;");
            
        }
    }
}
