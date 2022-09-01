using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Base.BackEnd.Api.Models.Clube;
using Projeto.Base.BackEnd.Application.Commands.Clube;
using System;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Api.Controllers
{
    public class ClubeController : MainController
    {
        private readonly IMediator _mediator;

        public ClubeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("buscar-clube-por-id/{id}")]
        public async Task<IActionResult> BuscarClubePorId(int id)
        {
            try
            {
                var clube = await _mediator.Send(new BuscarClubePorIdCommand(id));
                return Ok(clube);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("cadastrar-clube")]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] CadastrarClubeModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest();

                return Ok(await _mediator.Send(new CadastrarClubeCommand(model.Nome, model.AnoFundacao, model.UrlRedeSocial, model.EstadioId)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("buscar-clubes")]
        public async Task<IActionResult> BuscarEstadios()
        {
            try
            {
                var clubes = await _mediator.Send(new ListarClubeCommand());
                return Ok(clubes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("deletar-clube/{id}")]
        public async Task<IActionResult> DeletarEstadio(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeletarClubeCommand(id)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut, Route("editar-clube")]
        public async Task<IActionResult> EditarClube([FromBody] EditarClubeModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest();

                return Ok(await _mediator.Send(new EditarClubeCommand(model.Id, model.Nome, model.AnoFundacao, model.UrlRedeSocial, model.Ativo)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
