using System;
using System.Collections.Generic;
using System.Linq;
using ExemploDDD.Domain.Interfaces.Commands;
using ExemploDDD.Domain.Models;
using Flunt.Notifications;
using Flunt.Validations;

namespace ExemploDDD.Domain.Commands
{
    public class CriarClienteCommand : Notifiable, ICommand
    {
        public CriarClienteCommand(string nome, List<string> telefones)
        {
            Nome = nome; 
            Telefones = telefones;           
            Validar();        
        }

        public List<Telefone> _telefones
        {
            get{
            var tl = new List<Telefone>();
            foreach(var tel in Telefones)
            {
                var tele = new Telefone(tel);
                if(tele.Valid)
                    tl.Add(tele);                
            }
            return tl;
            }
        }

        public string Nome { get; set; }
        public List<string> Telefones  {get;set;}
        public void Validar()
        {   
            foreach(var tel in Telefones)
            {
                var t = new Telefone(tel);
                AddNotifications(t);
            }
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 5, "Cliente.Nome", "O Nome do cliente deve ter no mínim o 5 caracteres")                
            );
        }
    }
}