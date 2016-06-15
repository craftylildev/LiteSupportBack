using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSupport.Models
{
    public class LSContext : DbContext
    {
        public LSContext(DbContextOptions<LSContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<Ttype> Ttype { get; set; }

    }
}
