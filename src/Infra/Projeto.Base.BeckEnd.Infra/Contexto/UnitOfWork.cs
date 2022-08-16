using Projeto.Base.BackEnd.Domain.Entidades.Base;
using Projeto.Base.BackEnd.Domain.Entidades.Base.Interfaces;
using System.Diagnostics;

namespace Projeto.Base.BackEnd.Infra.Contexto
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModeloDbContext _context;

        public UnitOfWork(ModeloDbContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            try
            {
                _context.SaveChanges();
                return new CommandResponse(true);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message);
                return new CommandResponse();
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
