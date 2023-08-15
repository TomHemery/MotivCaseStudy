using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MotivWebApp.Models;

namespace MotivWebApp.Data
{
    public class MotivWebAppContext : DbContext
    {
        public MotivWebAppContext (DbContextOptions<MotivWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MotivWebApp.Models.QuoteRequest> QuoteRequest { get; set; } = default!;
    }
}
