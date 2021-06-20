using backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Phone> Phones { get; set; }
    
    }
}