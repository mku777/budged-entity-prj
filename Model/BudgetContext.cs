using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tfmpj.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace tfmpj.Model
{
    public class BudgetContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=Shamaks;Initial Catalog=tfm;Integrated Security=true;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
        .Property(u => u.Budget)
        .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
    .Property(t => t.Amount)
    .HasPrecision(18, 2); // Максимально 18 цифр в числе, 2 из которых после запятой

            modelBuilder.Entity<Transaction>()
           .HasOne(t => t.User)
           .WithMany()
           .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Transaction>()
                       .HasOne(t => t.Category)
                       .WithMany(c => c.Transactions)
                       .HasForeignKey(t => t.CategoryId);
        }
    }
}
