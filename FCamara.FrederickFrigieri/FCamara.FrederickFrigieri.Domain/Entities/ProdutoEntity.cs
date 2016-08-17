using System;

namespace FCamara.FrederickFrigieri.Domain.Entities
{
    public sealed class ProdutoEntity : Core.EntityBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }

        public ProdutoEntity(string nome, string descricao, decimal preco)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("O campo Nome é obrigatório.");

            if (string.IsNullOrEmpty(descricao))
                throw new Exception("O campo Descrição é obrigatório.");

            if (preco < 0)
                throw new Exception("O campo Preço não pode ser menor que 0.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public ProdutoEntity()
        {

        }
    }
}
