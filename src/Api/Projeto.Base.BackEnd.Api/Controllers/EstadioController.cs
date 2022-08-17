using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Api.Controllers
{
    public class EstadioController : MainController
    {
        private readonly IMediator _mediator;

        public EstadioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("cadastrar-estadio")]
        public async Task<IActionResult> CadastrarEmpresa()
        {
            try
            {
                return Ok(await _mediator.Send(new CadastrarEstadioCommand("Morumbi", "Brasil", true)));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("buscar-estadio-por-id/{id}")]
        public async Task<IActionResult> BuscarClubePorId(int id)
        {
            try
            {
                var estadio = await _mediator.Send(new BuscarEstadioPorIdCommand(id));
                return Ok(estadio);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("deletar-estadio-por-id/{id}")]
        public async Task<IActionResult> DeletarClubePorId(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeletarEstadioCommand(id)));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
