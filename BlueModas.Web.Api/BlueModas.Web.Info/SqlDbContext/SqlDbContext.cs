using BlueModas.Web.Info.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Web.Info.SqlDbContext
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options) { }

        public DbSet<ProductInfo> Product { get; set; }
        public DbSet<SaleInfo> Sale { get; set; }
    }
}
