using Microsoft.EntityFrameworkCore;
using PracticaIntegradora4.Entities;

namespace PracticaIntegradora4.Data
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}