using System;
using Microsoft.EntityFrameworkCore;
using SocialMedia.DAL.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia.DAL.Database 
{ 
    public class SocialMediaDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options)
        {

        }
       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
