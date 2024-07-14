using HC.Core.Domain;
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
    }
}
