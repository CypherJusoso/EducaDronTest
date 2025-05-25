using EducadronAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EducadronAPI.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
