using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.ProximaParada.Domain.Contracts.Repositories.Core
{
    public interface IConsultarRepository<T, TCodigo>
    {
        T ObterAmigoQueEstou(TCodigo codigoAmigo);
        IEnumerable<T> ObterTodosAmigos();
    }
}
