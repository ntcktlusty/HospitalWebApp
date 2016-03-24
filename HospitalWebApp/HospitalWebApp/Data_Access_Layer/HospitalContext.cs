using HospitalWebApp.Models;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HospitalWebApp.Data_Access_Layer
{
    public class HospitalContext: DbContext
    {
        public HospitalContext() : base("HospitalContext")
        {
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
