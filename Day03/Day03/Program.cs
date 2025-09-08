using Day03.DbContext;
using Day03.Models;
using Microsoft.EntityFrameworkCore;

namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Day03DB;Trusted_Connection=True;TrustServerCertificate=True");

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                Console.WriteLine("Database created successfully!");
                Console.WriteLine("Project configuration applied:");
                Console.WriteLine("- Id: Primary Key with Identity (10,10)");
                Console.WriteLine("- Name: varchar(50), Required, Default='OurProject'");
                Console.WriteLine("- Cost: Money datatype");

                var project = new Project
                {
                    Name = "Test Project",
                    Cost = 1000000
                };

                context.Projects.Add(project);
                context.SaveChanges();

                Console.WriteLine($"Project added with Id: {project.Id}");
                Console.WriteLine($"Project Name: {project.Name}");
                Console.WriteLine($"Project Cost: {project.Cost}");
            }
        }
    }
}