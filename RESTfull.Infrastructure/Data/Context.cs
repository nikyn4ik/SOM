using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RESTfull.Domain;

namespace RESTfull.Infrastructure //логика взаимодействия с СУБД
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
    }
}