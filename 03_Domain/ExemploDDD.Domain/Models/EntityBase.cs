using System;
using Flunt.Notifications;

namespace ExemploDDD.Domain.Models
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id {get;set;}

        public abstract void Validar();
    }
}