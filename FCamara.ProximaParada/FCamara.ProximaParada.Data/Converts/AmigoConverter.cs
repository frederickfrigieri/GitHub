using FCamara.ProximaParada.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace FCamara.ProximaParada.Data.Converts
{
    public static class AmigoConverter
    {
        public static IEnumerable<AmigoEntity> ToEntity(this StreamReader dados)
        {
            string linha;
            var amigos = new List<AmigoEntity>();

            while ((linha = dados.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(linha))
                {
                    var amigo = linha.ToEntity();
                    amigos.Add(amigo);
                }
            }

            dados.Close();

            return amigos;
        }

        public static AmigoEntity ToEntity(this string linha)
        {
            var amigo = new AmigoEntity(
                Convert.ToInt32(linha.Split('|')[0]),
                linha.Split('|')[1].Trim(), 
                Convert.ToDouble(linha.Split('|')[2]), 
                Convert.ToDouble(linha.Split('|')[3])
                );

            return amigo;
        }
    }
}
