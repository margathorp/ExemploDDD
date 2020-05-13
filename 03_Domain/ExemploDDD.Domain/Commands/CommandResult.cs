using System.Collections.Generic;
using ExemploDDD.Domain.Interfaces.Commands;
using Flunt.Notifications;

namespace ExemploDDD.Domain.Commands
{
    public class CommandResult : Notifiable, ICommandResult
    {
        public CommandResult()
        {
            
        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public CommandResult(bool success, string message, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Message = message;
            AddNotifications(notifications);
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}