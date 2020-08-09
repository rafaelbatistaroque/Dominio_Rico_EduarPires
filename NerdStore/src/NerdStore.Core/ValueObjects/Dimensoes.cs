using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.ValueObjects
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorOuIgualMinimo(altura, 1, "O campo Altura não pode ser menor ou igual 0;");
            Validacoes.ValidarSeMenorOuIgualMinimo(largura, 1, "O campo Largura não pode ser menor ou igual 0;");
            Validacoes.ValidarSeMenorOuIgualMinimo(profundidade, 1, "O campo Profundidade não pode ser menor ou igual 0;");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
