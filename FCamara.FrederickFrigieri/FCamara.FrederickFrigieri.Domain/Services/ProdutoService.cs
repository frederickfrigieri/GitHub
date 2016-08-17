using FCamara.FrederickFrigieri.Domain.Contracts.Services;
using System.Collections.Generic;
using FCamara.FrederickFrigieri.Domain.Entities;
using FCamara.FrederickFrigieri.Domain.Contracts.Repositories;

namespace FCamara.FrederickFrigieri.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoEntity> ObterTodos()
        {
            return _produtoRepository.ObterTodos();
        }
    }
}
