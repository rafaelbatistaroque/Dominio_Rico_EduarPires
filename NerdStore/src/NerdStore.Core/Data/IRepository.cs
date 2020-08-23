using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        public IUnitOfWork UnitOfWork { get; }

        Task<IQueryable<T>> ObterTodos();
        Task<IQueryable<T>> ObterPorCategoria(int codigo);
        Task<T> ObterPorId(Guid Id);

        void Adicionar(T entidade);
        void Atualizar(T entidade);
    }
}
