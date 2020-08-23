using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepositorio
    {
        private readonly CatalogoContext _context;


        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Produto entidade)
        {
            _context.Produtos.Add(entidade);
        }

        public void Atualizar(Produto entidade)
        {
            _context.Produtos.Update(entidade);
        }

        public async Task<IQueryable<Produto>> ObterPorCategoria(int codigo)
        {
            return (IQueryable<Produto>)await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public Task<Produto> ObterPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Produto>> ObterTodos()
        {
            return (IQueryable<Produto>)await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
