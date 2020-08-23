using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x => x.Imagem);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(250)");
            builder.Property(x => x.Imagem).IsRequired().HasColumnType("varchar(250)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("varchar(500)");
            builder.OwnsOne(x => x.Dimensoes,
                d =>
                {
                    d.Property(y => y.Altura).HasColumnName("Altura").HasColumnType("int");
                    d.Property(y => y.Largura).HasColumnName("Largura").HasColumnType("int");
                    d.Property(y => y.Profundidade).HasColumnName("Profundidade").HasColumnType("int");
                });
        }
    }
}
