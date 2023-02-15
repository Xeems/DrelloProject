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
        public DbSet<ATask> Tasks => Set<ATask>();
        public DbSet<PersonalTask> PersonalTasks=> Set<PersonalTask>();

        public DbSet<UserInBoard> UserInBoards=> Set<UserInBoard>();

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DrelloDB;Trusted_Connection=True;");
        }
    }
}
