using System;
using System.Threading.Tasks;
using ERP.Infra.Data.Context;
using ExemploDDD.Domain.Interfaces.Repositories;
using ExemploDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ClienteContext _context;
        public ClienteRepository(ClienteContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByIdInclude(Guid id)
        {
            return await _context.Clientes
                        .AsNoTracking()
                        .Include(x => x.Telefones)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> PossuiTelefone(Guid idCliente, string numero)
        {
            return _context.Telefones.AnyAsync(x => x.IdCliente == idCliente && x.Numero == numero);
        }

     
    }
}