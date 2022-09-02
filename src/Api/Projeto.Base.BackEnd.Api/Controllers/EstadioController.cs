using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto.Base.BackEnd.Api.Models.Estadio;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Api.Controllers
{
    public class EstadioController : MainController
    {
        private readonly IMediator _mediator;
        private readonly ConnectionFactory _factory;
        private const string queueName = "messages";

        public EstadioController(IMediator mediator)
        {
            _mediator = mediator;
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
        }

        [HttpPost, Route("cadastrar-estadio")]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] CadastrarEstadioModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest();

                using (var connection = _factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare
                            (
                                queue: queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null
                            );

                        var stringFieldMessage = JsonConvert.SerializeObject(model);
                        var bytesMessage = Encoding.UTF8.GetBytes(stringFieldMessage);

                        channel.BasicPublish(
                                exchange: "",
                                routingKey: queueName,
                                basicProperties: null,
                                body: bytesMessage
                            );
                    }

                    return Accepted(await _mediator.Send(new CadastrarEstadioCommand(model.Nome, model.Pais)));
                }
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
                if (model == null)
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
