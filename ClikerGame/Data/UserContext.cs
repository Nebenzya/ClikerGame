using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static ClikerGame.Data.UserModel;

namespace ClikerGame.Data
{
      public class UserContext : DbContext
      {
            public DbSet<User> Users { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  modelBuilder.Entity<User>().Property(d => d.Nickname).IsRequired();
                  modelBuilder.Entity<User>().ToTable(t => t.HasCheckConstraint("Nickname", "Nickname <> ''"));
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                  //optionsBuilder.UseSqlite(@"Data Source=UsersDB.db");
                  optionsBuilder.UseSqlite(@"Data Source=../../../Data/UsersDB.db");
                  //optionsBuilder.UseSqlite(@"Filename=../../../GamersDB.sqlite");
                  //optionsBuilder.UseSqlite(@"Data Source=../../../GamersDB.sqlite");
                  //optionsBuilder.UseSqlite(@"Filename=../../../Migrations/GamersDB.sqlite");
            }
      }
}
