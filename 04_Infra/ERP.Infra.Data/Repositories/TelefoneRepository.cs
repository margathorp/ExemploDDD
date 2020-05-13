using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Infra.Data.Context;
using ExemploDDD.Domain.Interfaces.Repositories;
using ExemploDDD.Domain.Models;

namespace ERP.Infra.Data.Repositories
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        private readonly ClienteContext _context;
        public TelefoneRepository(ClienteContext context) : base(context)
        {
            _context = context;
        }

        public List<Telefone> GetByIdUserAsync(Guid idCliente)
        {
            return _context.Telefones.Where(x => x.IdCliente == idCliente).ToList();
        }
    }
}