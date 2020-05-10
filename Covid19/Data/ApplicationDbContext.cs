using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Covid19.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //  builder.Entity<State>().HasData(new State { Id = 1, Name = "Khartoum" },
            //new State { Id = 2, Name = "Kasala" },
            //new State { Id = 3, Name = "Nahr Elniel" },
            //new State { Id = 4, Name = "Red Sea" },
            //new State { Id = 5, Name = "Shamalyya" });

            //  builder.Entity<Municipality>().HasData(new Municipality { Id = 1, Name = "Khartoum" },
            //     new Municipality { Id = 2, Name = "Bahri" },
            //     new Municipality { Id = 3, Name = "Omdurman" }
            //     );
            base.OnModelCreating(builder);



        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Status> Status { get; set; }



        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
