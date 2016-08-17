using FCamara.ProximaParada.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.ProximaParada.Domain.Contracts.Services
{
    public interface IAmigoService
    {
        IEnumerable<AmigoEntity> ObterProximos(AmigoEntity amigoQueEstou);
        AmigoEntity ObterAmigoQueEstou(int codigoAmigo);
        IEnumerable<AmigoEntity> ObterTodosAmigos();

        AmigoEntity AdicionarAmigo(AmigoEntity entity);
    }
}
