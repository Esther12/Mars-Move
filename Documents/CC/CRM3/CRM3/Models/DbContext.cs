using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CRM3.Models
{
    public class DbContext : IdentityDbContext<MyIdentityUser>
    {
        public DbContext()
        {
        }
    }
    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate {get; set; }
        public String Bio { get; set;  }
    }

    public class MyIdentityRole : IdentityRole
    {
        public MyIdentityRole()
        {
            
        }
        public MyIdentityRole(string roleName, string description) : base(roleName)
        {
            this.Description = description;
        }

        public string Description { get; set; }

    }

}
