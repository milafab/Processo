using Microsoft.EntityFrameworkCore;
using ProcessoApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoApi.Repository
{
    public class PostgreeContext:DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options) : base(options) { }

        public DbSet<DadosProcesso> Processo { get; set; }
    }
}
