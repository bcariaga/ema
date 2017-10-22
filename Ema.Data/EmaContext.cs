using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ema.Data
{
    public class EmaContext : DbContext
    {
        public EmaContext(DbContextOptions options) : base(options) { }

       
        public DbSet<Movimiento> Movimientos { get; set; }
    }
}
