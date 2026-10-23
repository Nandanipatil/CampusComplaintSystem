using Microsoft.EntityFrameworkCore;
using CampusComplaintSystem.Models;

namespace CampusComplaintSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Complaint> Complaints { get; set; }
    }
}