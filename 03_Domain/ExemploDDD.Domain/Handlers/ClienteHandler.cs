
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
        IRequestHandler<CriarTelefoneCommand, ICommandResult>,
        IRequestHandler<CriarTelefoneValidacaoCommand, ICommandResult>,
        IRequestHandler<ObterTelefonesClienteCommand, ICommandResult>
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
            AddNotifications(command);
            if(Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }
            
            Cliente cliente = new Cliente(command.Nome);
            
            AddNotifications(cliente);
            if(Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }
            await _clienteRepository.AddAsync(cliente);

            return new CommandResult(true, $"O Cliente {cliente.Id} - {cliente.Nome} foi criado com sucesso!");
        }

        public async  Task<ICommandResult> Handle(CriarTelefoneCommand command, CancellationToken cancellationToken)
        {
            AddNotifications(command);
            if(Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }

            Telefone telefone = new Telefone(command.IdCliente, command.Numero);
            AddNotifications(telefone);
            if(Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }

            await _telefoneRepository.AddAsync(telefone);
            
            return new CommandResult(true, $"O telefone {command.Numero} foi criado com sucesso!");
        }

        public async Task<ICommandResult> Handle(CriarTelefoneValidacaoCommand command, CancellationToken cancellationToken)
        {
            AddNotifications(command);
            if(Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }
            Cliente cliente = await _clienteRepository.GetByIdInclude(command.IdCliente);
            if(cliente == null)
                return new CommandResult(true, $"O telefone {command.Numero} foi criado com sucesso!");
            
            cliente.AddTelefone(new Telefone(command.IdCliente, command.Numero));

            AddNotifications(cliente);
            if(Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }
            
            await _clienteRepository.UpdateAsync(cliente);

            return new CommandResult(true, $"O telefone {command.Numero} foi criado com sucesso!");
        }

        public async Task<ICommandResult> Handle(ObterTelefonesClienteCommand command, CancellationToken cancellationToken)
        {
            AddNotifications(command);
            if(Invalid)
            {
                return new CommandResult(false, "Dados Inválidos!", Notifications);                
            }
            
            return new CommandResultLista(_telefoneRepository.GetByIdUserAsync(command.IdCliente));

        }
        
    }
}