using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {
            
        }

        public DbSet<UserMeter> UserMeters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMeter>().HasKey(i => i.Id);
            modelBuilder.Entity<UserMeter>().Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
