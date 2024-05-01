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
