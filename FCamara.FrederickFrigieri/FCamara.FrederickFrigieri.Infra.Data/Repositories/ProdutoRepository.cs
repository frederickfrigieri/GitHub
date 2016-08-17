using FCamara.FrederickFrigieri.Domain.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using FCamara.FrederickFrigieri.Domain.Entities;
using FCamara.FrederickFrigieri.Infra.Data.Contexts;

namespace FCamara.FrederickFrigieri.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Contexto _contexto;

        public ProdutoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<ProdutoEntity> ObterTodos()
        {
            return _contexto.ProdutoEntities
                            .ToList();
        }
    }
}
