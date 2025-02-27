using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaDeContatosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatosMVC.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {

            
        }

        public DbSet<Usuarios> Usuarios{get; set;}

        public DbSet<Autenticacoes> Autenticacoes {get; set;}

        public DbSet<Administradores> Administradores {get; set;}

        public DbSet<AutenticacoesAdmins> AutenticacoesAdmins {get; set;}
    }
}