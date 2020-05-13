using System.Collections.Generic;
using ExemploDDD.Domain.Interfaces.Commands;
using ExemploDDD.Domain.Models;

namespace ExemploDDD.Domain.Commands
{
    public class CommandResultLista : ICommandResult
    {
        public CommandResultLista(List<Telefone> telefones)
        {
            Telefones = telefones;
        }

        public List<Telefone> Telefones { get; set; }
    }
}