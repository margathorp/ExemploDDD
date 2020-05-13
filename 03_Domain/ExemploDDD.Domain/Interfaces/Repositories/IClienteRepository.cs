using System;
using System.Threading.Tasks;
using ExemploDDD.Domain.Models;

namespace ExemploDDD.Domain.Interfaces.Repositories
{
    public interface IClienteRepository: IRepository<Cliente>
    {
         Task<Cliente> GetByIdInclude(Guid id);
         Task<bool> PossuiTelefone(Guid idCliente, string numero);
    }
}