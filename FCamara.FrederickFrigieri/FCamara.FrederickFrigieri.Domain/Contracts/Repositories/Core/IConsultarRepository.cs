using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.FrederickFrigieri.Domain.Contracts.Repositories.Core
{
    public interface IConsultarRepository<T> where T : class
    {
        IEnumerable<T> ObterTodos();
    }
}
