﻿using DbServer.Data.Mapping;
using DbServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Data.Context
{
    public class SqlContext : DbContext
    {
        public DbSet<CheckingAccount> CheckingAccount { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CheckingAccount>(new CheckingAccountMap().Configure);
            modelBuilder.Entity<Post>(new PostMap().Configure);
        }
    }
}
