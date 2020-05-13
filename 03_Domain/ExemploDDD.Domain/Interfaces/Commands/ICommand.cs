using MediatR;

namespace ExemploDDD.Domain.Interfaces.Commands
{
    public interface ICommand: IRequest<ICommandResult>
    {
         void Validar();
    }
}