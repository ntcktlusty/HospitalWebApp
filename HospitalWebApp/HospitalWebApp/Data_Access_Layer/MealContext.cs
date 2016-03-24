using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HospitalWebApp.Models;

namespace HospitalWebApp.Data_Access_Layer
{
    public class MealContext : DbContext
    {

        public MealContext() : base("MealContext")
        {
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}