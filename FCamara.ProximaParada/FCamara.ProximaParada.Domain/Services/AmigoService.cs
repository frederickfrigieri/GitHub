using FCamara.ProximaParada.Domain.Contracts.Services;
using System.Collections.Generic;
using FCamara.ProximaParada.Domain.Entities;
using FCamara.ProximaParada.Domain.Contracts.Repositories;
using System.Device.Location;
using System.Linq;
using System;

namespace FCamara.ProximaParada.Domain.Services
{
    public class AmigoService : IAmigoService
    {
        private IAmigoRepository _amigoRepository;

        public AmigoService(IAmigoRepository amigoRepository)
        {
            _amigoRepository = amigoRepository;
        }

        public AmigoEntity AdicionarAmigo(AmigoEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Nome))
                throw new Exception("Nome é obrigatório");

            if (string.IsNullOrEmpty(entity.Latitude.ToString()) || entity.Latitude == 0)
                throw new Exception("Latitude com valor inválido.");

            if (string.IsNullOrEmpty(entity.Longitude.ToString()) || entity.Longitude == 0)
                throw new Exception("Longitude com valor inválido.");

            var jaExisteAmigo = ObterTodosAmigos()
                .Where(x => x.Latitude == entity.Latitude && x.Longitude == entity.Longitude)
                .FirstOrDefault();
                
            if (jaExisteAmigo != null)
                throw new Exception("Já existe um usuário cadastrado nesta posição");

            return _amigoRepository.Adicionar(entity);
        }

        public AmigoEntity ObterAmigoQueEstou(int codigoAmigo)
        {
            return _amigoRepository.ObterAmigoQueEstou(codigoAmigo);
        }

        public IEnumerable<AmigoEntity> ObterProximos(AmigoEntity amigoQueEstou)
        {
            var todosAmigos = ObterTodosAmigos().ToList();
            var coordenadaOrigem = new GeoCoordinate(amigoQueEstou.Latitude, amigoQueEstou.Longitude);
            var proximos = todosAmigos
                .Where(x=>x.Codigo != amigoQueEstou.Codigo)
                .OrderBy(x => coordenadaOrigem.GetDistanceTo(new GeoCoordinate(x.Latitude, x.Longitude)))
                .Take(3);

            return proximos;
        }

        public IEnumerable<AmigoEntity> ObterTodosAmigos()
        {
            return _amigoRepository.ObterTodosAmigos();
        }
    }
}
