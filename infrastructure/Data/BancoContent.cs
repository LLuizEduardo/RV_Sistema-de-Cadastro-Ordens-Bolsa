using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RV.Domain.Models;

namespace RV
{
    public class BancoContent : DbContext
    {
        public BancoContent(DbContextOptions<BancoContent> options) : base(options)
        {
        }

        public DbSet<AcaoModel> Acoes { get; set; }
        public DbSet<OpcaoModel> Opcoes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
