using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using Projeto.Base.BackEnd.Application.ValueObjects;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Estadio
{
    public class ListarEstadiosHandler : IRequestHandler<ListarEstadioCommand, List<EstadioVO>>
    {
        private readonly IEstadioRepositorio _repositorio;

        public ListarEstadiosHandler(IEstadioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<EstadioVO>> Handle(ListarEstadioCommand request, CancellationToken cancellationToken)
        {
            var estadios = await _repositorio.BuscarAsync(x => x.DataExclusao == null);
            var retornoLista = new List<EstadioVO>();

            foreach (var estadio in estadios)
            {
                var estadioVo = new EstadioVO()
                {
                    Id = estadio.Id,   
                    Nome = estadio.Nome,
                    Ativo = estadio.Ativo,
                    DataAlteracao = estadio.DataAlteracao,
                    DataInclusao = estadio.DataInclusao,    
                    Pais = estadio.Pais,
                    DataExclusao = estadio.DataExclusao,
                };

                retornoLista.Add(estadioVo);
            }

            return retornoLista;
        }
    }
}
