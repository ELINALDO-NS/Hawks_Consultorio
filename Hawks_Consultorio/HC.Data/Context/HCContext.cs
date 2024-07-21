using HC.Core.Domain;
using HC.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Data.Context
{
    public class HCContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public HCContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        }
    }
}
