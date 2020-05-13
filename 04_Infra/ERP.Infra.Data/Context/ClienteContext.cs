using ERP.Infra.Data.Maps;
using ExemploDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Telefone> Telefones {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Telefone>(new TelefoneMap().Configure);    
                    
        }
        
    }
}