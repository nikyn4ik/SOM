using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RESTfull.Domain;

namespace RESTfull.Infrastructure //логика взаимодействия с СУБД
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) 
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        ////public DbSet<User> Users => Set<User>();
        ////public Context() => Database.EnsureCreated();

        ////protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////{
        ////    optionsBuilder.UseSqlServer("RESTfull", builder =>
        ////    {
        ////        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        ////    });
        ////    base.OnConfiguring(optionsBuilder);
        ////}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Users>()
        //    //    .ToTable("Users").HasKey(p => p.Id);
        //    modelBuilder.Entity<User>().ToTable("Users");
        //}
    }
}