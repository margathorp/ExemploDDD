using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ERP.Infra.Data
{
    public class ClienteContextFactory : IDesignTimeDbContextFactory<ClienteContext>
    {
        public ClienteContext CreateDbContext(string[] args)
        {
            var connection = "Server=localhost;User Id=root;Password=mz0079tuk6;Database=Teste_Cliente;TreatTinyAsBoolean=false";
            var optionsBuilder = new DbContextOptionsBuilder<ClienteContext>();
            optionsBuilder.UseMySql(connection);            
            return new ClienteContext(optionsBuilder.Options);
        }
    }
}