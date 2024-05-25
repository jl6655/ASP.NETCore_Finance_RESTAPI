using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions) // base passes dbContextOptions into DbContext
        {
            
        }

        public DbSet<Stock> Stocks { get; set; } // Allows you to manipulate the entire stock table
        public DbSet<Comment> Comments { get; set; }
    }
}