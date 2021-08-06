using AcademyC.Week4.Test.Core.Models;
using AcademyC.Week4.Test.CoreEF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace AcademyC.Week4.Test.CoreEF
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Context() : base() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Client_Order_ManagementDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Client>(new ClientConfiguration());
            builder.ApplyConfiguration<Order>(new OrderConfiguration());
        }




    }
}
