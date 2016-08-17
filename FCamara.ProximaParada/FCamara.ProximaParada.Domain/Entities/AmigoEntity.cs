using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.ProximaParada.Domain.Entities
{
    public sealed class AmigoEntity : Core.EntityBase
    {
        public string Nome { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }


        public AmigoEntity(string nome, double latitude, double longitude)
        {
            ValidarCampos(nome: nome, latitude: latitude, longitude: longitude);

            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
        }

        public AmigoEntity(Int32 codigo, string nome, double latitude, double longitude)
        {
            ValidarCampos(nome, latitude, longitude, codigo);

            Codigo = codigo;
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return String.Format(@"Codigo: {0}, Amigo: {1}, Latitude: {2}, Longitude:{3}", 
                Codigo, Nome, Latitude, Longitude);
        }

        private void ValidarCampos(string nome, double latitude, double longitude, Int32? codigo = null)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Nome campo inválido.");

            if (latitude == 0)
                throw new Exception("Latitude não pode ser igual a 0.");

            if (longitude == 0)
                throw new Exception("Longitude não pode ser igual a 0.");

            if (codigo != null)
                if (codigo <= 0)
                    throw new Exception("Codigo inválido.");

        }
    }
}
