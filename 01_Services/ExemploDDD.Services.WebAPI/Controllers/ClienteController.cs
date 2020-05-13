using System;
using System.Threading.Tasks;
using ExemploDDD.Domain.Commands;
using ExemploDDD.Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExemploDDD.Services.WebAPI.Controllers
{
    [Route("/api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]        
        public async Task<IActionResult> CadastrarCliente([FromBody]CriarClienteCommand command)
        {   
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("{id}/add-telefone")]
        public async Task<IActionResult> AddTelefone([FromRoute] Guid id, [FromBody] string numero)
        {
            var command = new CriarTelefoneCommand(id, numero);
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("{id}/add-telefone-validacao")]
        public async Task<IActionResult> AddTelefoneValidacao([FromRoute] Guid id, [FromBody] string numero)
        {
            var command = new CriarTelefoneValidacaoCommand(id, numero);
            return Ok(await _mediator.Send(command));
        }
    }
}   