using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Flunt.Validations;

namespace ExemploDDD.Domain.Models
{
    public class Cliente : EntityBase
    {
        protected Cliente()
        {
            _telefones = new List<Telefone>();
        }
        public Cliente(string nome)
        {
            Nome = nome;            
            _telefones = new List<Telefone>();
            Validar();
        }

        public string Nome { get; private set; }
        private List<Telefone> _telefones;
        public IReadOnlyCollection<Telefone> Telefones  => _telefones.AsReadOnly();

        public void AddTelefone(Telefone telefone)
        {
            AddNotifications(telefone);
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(VerificarTelefoneExistente(telefone), "Cliente.Telefone", "Este telefone já existe")
            );
            if(Valid)
            {
                _telefones.Add(telefone);
            }            
        }

        private bool VerificarTelefoneExistente(Telefone telefone)
        {
            var teste = _telefones.Any(x => x.Numero.Equals(telefone.Numero));
            return teste;
        }
        public override void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 5, "Cliente.Nome", "O Nome do cliente deve ter no mínimo 5 caracteres")
            );
        }

        public void AddTelefones(List<Telefone> telefones)
        {
            foreach(var tel in telefones)
            {
                AddTelefone(tel);
            }
        }
    }
}