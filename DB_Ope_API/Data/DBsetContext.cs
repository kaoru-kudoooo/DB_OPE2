using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB_Ope_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_Ope_API.Data
{
    public class DBsetContext:DbContext
    {
        public DBsetContext(DbContextOptions<DBsetContext> options)
        : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
