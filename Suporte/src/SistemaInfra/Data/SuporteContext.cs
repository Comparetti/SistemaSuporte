using Microsoft.EntityFrameworkCore;
using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInfra.Data
{
    public class SuporteContext : DbContext
    {
        public SuporteContext(DbContextOptions<SuporteContext> options) : base (options)
        {
        }
        public DbSet<Intermeio> Intermeio { get; set; }
        public DbSet<Phoebus> Phoebus { get; set; }
        public DbSet<Analise> Analise { get; set; }
    }
}
