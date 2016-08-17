using FCamara.ProximaParada.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.ProximaParada.Domain.Contracts.Repositories
{
    public interface IAmigoRepository 
        : Core.IConsultarRepository<AmigoEntity, int>
    {
        AmigoEntity Adicionar(AmigoEntity entity);
    }
}
