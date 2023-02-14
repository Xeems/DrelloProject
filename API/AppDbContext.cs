using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DrelloApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<KanBoard> Boards => Set<KanBoard>();
        public DbSet<BoardRole> BoardRoles => Set<BoardRole>();

        public AppDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
