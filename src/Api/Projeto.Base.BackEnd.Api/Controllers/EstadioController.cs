using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Base.BackEnd.Api.Models.Estadio;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using System;
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
        public async Task<IActionResult> CadastrarEmpresa([FromBody] CadastrarEstadioModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest();

                return Ok(await _mediator.Send(new CadastrarEstadioCommand(model.Nome, model.Pais)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("buscar-estadio-por-id/{id}")]
        public async Task<IActionResult> BuscarEstadioPorId(int id)
        {
            try
            {
                var estadio = await _mediator.Send(new BuscarEstadioPorIdCommand(id));
                return Ok(estadio);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("buscar-estadios")]
        public async Task<IActionResult> BuscarEstadios()
        {
            try
            {
                var estadios = await _mediator.Send(new ListarEstadioCommand());
                return Ok(estadios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("deletar-estadio/{id}")]
        public async Task<IActionResult> DeletarEstadio(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeletarEstadioCommand(id)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut, Route("editar-estadio")]
        public async Task<IActionResult> EditarClube([FromBody] EditarEstadioModel model)
        {
            try
            {
                if(model == null)
                   return BadRequest();

                return Ok(await _mediator.Send(new EditarEstadioCommand(model.Id, model.Nome, model.Pais, model.Ativo)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
