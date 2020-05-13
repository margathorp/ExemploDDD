
using System.Threading;
using System.Threading.Tasks;
using ExemploDDD.Domain.Commands;
using ExemploDDD.Domain.Interfaces.Commands;
using ExemploDDD.Domain.Interfaces.Handlers;
using ExemploDDD.Domain.Interfaces.Repositories;
using ExemploDDD.Domain.Models;
using Flunt.Notifications;
using MediatR;

namespace ExemploDDD.Domain.Handlers
{
    public class ClienteHandler : 
        Notifiable, 
        IRequestHandler<CriarClienteCommand,ICommandResult>, 
        IRequestHandler<CriarTelefoneCommand, ICommandResult>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITelefoneRepository _telefoneRepository;

        public ClienteHandler(IClienteRepository clienteRepository,
                              ITelefoneRepository telefoneRepository)
        {
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;
        }

        public async Task<ICommandResult> Handle(CriarClienteCommand command, CancellationToken cancellationToken)
        {
            if(command.Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", command.Notifications);                
            }
            
            Cliente cliente = new Cliente(command.Nome);            
            cliente.AddTelefones(command._telefones);
            if(cliente.Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", cliente.Notifications);                
            }
            await _clienteRepository.AddAsync(cliente);

            return new CommandResult(true, $"O Cliente {cliente.Id} - {cliente.Nome} foi criado com sucesso!");
        }

        public async  Task<ICommandResult> Handle(CriarTelefoneCommand command, CancellationToken cancellationToken)
        {
            if(command.Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", command.Notifications);                
            }
            if(await _clienteRepository.PossuiTelefone(command.IdCliente, command.Numero))
            {
                AddNotification("Telefone.Numero", "O Cliente já possui este telefone");
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }
            Telefone telefone = new Telefone(command.IdCliente, command.Numero);
            if(telefone.Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", telefone.Notifications);                
            }

            await _telefoneRepository.AddAsync(telefone);
            
            return new CommandResult(true, $"O telefone {command.Numero} foi criado com sucesso!");
        }        
    }
}