using System.Threading.Tasks;
using ExemploDDD.Domain.Interfaces.Commands;
using MediatR;

namespace ExemploDDD.Domain.Interfaces.Handlers
{
    public interface IHandler : IRequestHandler<ICommand, ICommandResult>
    {
        
    }
}