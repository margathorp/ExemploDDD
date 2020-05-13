using System;
using ExemploDDD.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ExemploDDD.Domain.Commands
{
    public class CriarTelefoneCommand : Notifiable, ICommand
    {
        public CriarTelefoneCommand(Guid idCliente, string numero)
        {
            IdCliente = idCliente;
            Numero = numero;
            Validar();
        }
        public Guid IdCliente { get; set; }
        public string Numero { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Guid.Empty, IdCliente, "Telefone.IdCliente", "Informar o Cliente")
                .IsNotNullOrEmpty(Numero, "Telefone.Numero", "Informe o número do telefone")
            );
        }
    }
}