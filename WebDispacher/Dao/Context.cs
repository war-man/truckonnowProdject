﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDispacher.Dao.Models;
using WebDispacher.DAO.Models;

namespace WebDispacher.Dao
{
    public class ContextP : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Shipping> Shipping { get; set; }

        public ContextP()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebDispatch;Trusted_Connection=True;");
            }
        }
    }
}
