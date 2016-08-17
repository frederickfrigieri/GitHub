using FCamara.ProximaParada.Domain.Contracts.Repositories;
using System.Collections.Generic;
using FCamara.ProximaParada.Domain.Entities;
using FCamara.ProximaParada.Data.Context;
using System.Linq;
using FCamara.ProximaParada.Data.Converts;
using System;
using System.IO;

namespace FCamara.ProximaParada.Data.Repositories
{
    public class AmigoRepository : IAmigoRepository
    {
        public AmigoEntity Adicionar(AmigoEntity entity)
        {
            var ultimoCodigo = ObterTodosAmigos()
                .OrderByDescending(x => x.Codigo)
                .FirstOrDefault();

            entity.Codigo = 1;
            if (ultimoCodigo != null)
                entity.Codigo = ++ultimoCodigo.Codigo;

            var dados = ProximaParadaContext.Obter("Amigos.txt");
            string converterText = String.Format("{0}|{1}|{2}|{3}",entity.Codigo, entity.Nome, entity.Latitude, entity.Longitude);

            using (StreamWriter sw = dados.AppendText())
            {
                sw.WriteLine(converterText.Trim());

                return entity;
            }
        }

        public AmigoEntity ObterAmigoQueEstou(int codigoAmigo)
        {
            var amigos = ObterTodosAmigos();
            var amigoQueEstou = amigos.Where(x => x.Codigo == codigoAmigo).FirstOrDefault();

            return amigoQueEstou;
        }

        public IEnumerable<AmigoEntity> ObterTodosAmigos()
        {
            var dados = ProximaParadaContext
                            .Obter("Amigos.txt")
                            .OpenText();
            
            return dados.ToEntity();
        }

    }
}
