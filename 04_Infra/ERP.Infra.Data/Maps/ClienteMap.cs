using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExemploDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Cliente.Telefones));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            
            builder.ToTable("Cliente");
            builder.Ignore(i => i.Notifications);    
            builder.HasKey(x => x.Id);                    
            builder.HasMany(c => c.Telefones)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.IdCliente);
        }
    }
}