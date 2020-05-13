using System;
using ExemploDDD.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ExemploDDD.Domain.Commands
{
    public class ObterTelefonesClienteCommand : Notifiable, ICommand
    {
        public Guid IdCliente { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreEquals(Guid.Empty, IdCliente, "Telefone.IdCliente", "Informar o Cliente")                
            );
        }
    }
}