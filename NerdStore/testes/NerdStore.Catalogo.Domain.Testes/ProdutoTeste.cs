using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.ValueObjects;
using System;

namespace NerdStore.Catalogo.Domain.Testes
{
    [TestClass]
    public class ProdutoTeste
    {
        [TestMethod]
        public void DevePassarSeNomeValido()
        {
            var nomeValido = "Produto1";
            var nomeInvalido = string.Empty;

            new Produto(nomeValido, "Descrição", false, 100, Guid.NewGuid(), DateTime.Now, "urlImagem", new Dimensoes(1, 1, 1));
        }


    }
}
