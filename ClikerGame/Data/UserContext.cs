using Microsoft.EntityFrameworkCore;

namespace ClikerGame.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(d => d.Nickname).IsRequired();
            modelBuilder.Entity<User>().ToTable(t => t.HasCheckConstraint("Nickname", "Nickname <> ''"));
            modelBuilder.Entity<Modifier>().Property(d => d.Name).IsRequired();
            modelBuilder.Entity<Modifier>().ToTable(nameof(Modifier)).HasCheckConstraint("Name", "Name <> ''");
            modelBuilder.Entity<User>().HasMany(c => c.Modifiers).WithMany(s => s.Users).UsingEntity<UserModifier>(j => j.HasOne(pt => pt.Modifier).WithMany(p => p.UserModifiers).HasForeignKey(pt => pt.ModifiersId), j => j.HasOne(pt => pt.User).WithMany(t => t.UserModifiers).HasForeignKey(pt => pt.UsersId), j =>
            {
                j.Property(pt => pt.QuantityOfModifiers).HasDefaultValue(0);
                j.HasKey(t => new { t.UsersId, t.ModifiersId });
                j.ToTable("UserModifier");
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=UsersDB.db");
            //optionsBuilder.UseSqlite(@"Data Source=../../../Data/UsersDB.db");
            //optionsBuilder.UseSqlite(@"Filename=../../../GamersDB.sqlite");
            //optionsBuilder.UseSqlite(@"Data Source=../../../GamersDB.sqlite");
            //optionsBuilder.UseSqlite(@"Filename=../../../Migrations/GamersDB.sqlite");
        }
    }
}
