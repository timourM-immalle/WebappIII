using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFirstWebAppII.Models
{
    public class MyFirstWebAppIIContext : DbContext
    {
        public MyFirstWebAppIIContext (DbContextOptions<MyFirstWebAppIIContext> options)
            : base(options)
        {
        }

        public DbSet<MyFirstWebAppII.Models.Punt> Punt { get; set; }
    }
}
