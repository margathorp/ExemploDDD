using System;
using Flunt.Validations;

namespace ExemploDDD.Domain.Models
{
    public class Telefone : EntityBase
    {
        protected Telefone(){}
        public Guid IdCliente { get; private set; }
        public string Numero { get; private set; }
        public Cliente Cliente {get;private set;}
        public Telefone(Guid idCliente, string numero)
        {
            IdCliente = idCliente;
            Numero = numero;
            Validar();
        }

        public Telefone(string numero)
        {
            Numero = numero;
        }

        public void EditarTelefone(string numero)
        {
            Numero = numero;
            Validar();
        }
        public override void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Guid.Empty, IdCliente, "Telefone.IdCliente", "Informar o Cliente")
                .IsNotNullOrEmpty(Numero, "Telefone.Numero", "Informe o número do telefone")
            );
        }
    }
}