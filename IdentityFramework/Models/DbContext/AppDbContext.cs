using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext()
            : base("name=AppModel")
        {
            Database.SetInitializer(new AppDBInitializer());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }




    }
