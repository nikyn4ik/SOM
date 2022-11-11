using Microsoft.EntityFrameworkCore;
using RESTfull.Domain;

namespace RESTfull.Infrastructure //логика взаимодействия с СУБД
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Users> Userss { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}