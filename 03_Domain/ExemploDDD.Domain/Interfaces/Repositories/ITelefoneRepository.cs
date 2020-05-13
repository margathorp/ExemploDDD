using System;
using System.Collections.Generic;
using ExemploDDD.Domain.Models;

namespace ExemploDDD.Domain.Interfaces.Repositories
{
    public interface ITelefoneRepository : IRepository<Telefone>
    {
        List<Telefone> GetByIdUserAsync(Guid idCliente);
    }
}