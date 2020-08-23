using NerdStore.Core.DomainObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        //EF
        public IReadOnlyCollection<Produto> Produtos { get; set; }

        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio.");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode estar 0.");
           
        }
    }
}
