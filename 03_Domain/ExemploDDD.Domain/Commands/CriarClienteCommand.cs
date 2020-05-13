using System;
using ExemploDDD.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ExemploDDD.Domain.Commands
{
    public class CriarClienteCommand : Notifiable, ICommand
    {
        public CriarClienteCommand(string nome)
        {
            Nome = nome;
            Validar();
        }
        public string Nome { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 5, "Cliente.Nome", "O Nome do cliente deve ter no mínim o 5 caracteres")
            );
        }
    }
}