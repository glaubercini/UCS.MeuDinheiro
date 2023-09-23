using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.EF.Context
{
    internal class MeuDinheiroContext : DbContext
    {
        private static readonly string Server = "localhost";
        private static readonly string User = "sa";
        private static readonly string DBname = "MeuDinheiro";
        private static readonly string Password = "blog_6109";

        public DbSet<Customer> Customer { get; set; }

        public DbSet<BankAccount> BankAccount { get; set; }

        public DbSet<BankAccountStatement> BankAccountStatement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(string.Format(
                    "Server={0};User Id={1};Database={2};Password={3};TrustServerCertificate=True",
                    Server,
                    User,
                    DBname,
                    Password));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
