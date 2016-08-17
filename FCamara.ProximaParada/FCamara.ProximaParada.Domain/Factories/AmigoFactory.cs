using FCamara.ProximaParada.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.ProximaParada.Domain.Factories
{
    public static class AmigoFactory
    {
        public static AmigoEntity Create(string nome, double latitude, double longitude)
        {
            return new AmigoEntity(nome, latitude, longitude);
        }

        public static AmigoEntity Create(int codigo, string nome, double latitude, double longitude)
        {
            return new AmigoEntity(codigo, nome, latitude, longitude);
        }

    }
}
