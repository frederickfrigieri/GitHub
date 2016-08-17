using FCamara.FrederickFrigieri.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.FrederickFrigieri.Infra.Data.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<ProdutoEntity>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasKey(x => x.Codigo)
                .Property(x => x.Codigo)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasColumnOrder(1);

            Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnOrder(2);

            Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnOrder(3);

            Property(x => x.Preco)
                .HasColumnName("Preco")
                .HasColumnType("decimal")
                .IsRequired()
                .HasPrecision(12,10)
                .HasColumnOrder(4);
        }
    }
}
