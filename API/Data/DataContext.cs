using API.Entities;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class DataContext : DbContext
  {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Todo>()
                    .Property(s => s.Id).IsRequired().HasMaxLength(100);
                base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>().HasData(
                new Todo(1, "Task1"), 
                new Todo(2, "Task2"),
                new Todo(3, "Task3"),
                new Todo(4, "Task4")
            );
        }
   }
}