using FCamara.FrederickFrigieri.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.FrederickFrigieri.Domain.Contracts.Services
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoEntity> ObterTodos();
    }
}
