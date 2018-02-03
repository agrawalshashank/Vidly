﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
    }
     
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}