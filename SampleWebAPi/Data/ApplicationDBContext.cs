using Microsoft.EntityFrameworkCore;
using SampleWebAPi.Models.Entities;

namespace SampleWebAPi.Data
{
    public class ApplicationDBContext: DbContext
    {
        //making a constructor to deal with the databse options 
       public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        //now its important to use db set to make a relationship between the entities and the database
        public DbSet<Employee> Employees{ get; set; }
    }
}
