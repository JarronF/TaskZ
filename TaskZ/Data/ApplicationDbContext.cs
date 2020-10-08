using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskZ.Models;

namespace TaskZ.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<TaskComment> TaskComment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);            

            //This scans a given assembly for all types that implement IEntityTypeConfiguration, and registers each one automatically.
            //It will run ConfigureXYZTable classes automatically
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Call the seed function of the SeedData class
            SeedData.Seed(builder);

        }
    }
}
