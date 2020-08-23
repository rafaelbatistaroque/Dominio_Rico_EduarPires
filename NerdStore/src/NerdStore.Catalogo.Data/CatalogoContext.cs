using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Data.Mappings;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(this).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entrada in ChangeTracker.Entries().Where(entrada => entrada.GetType().GetProperty("DataCadastro") != null))
            {
                if (entrada.State == EntityState.Added)
                    entrada.Property("DataCadastro").CurrentValue = DateTime.Now;
                if (entrada.State == EntityState.Modified)
                    entrada.Property("DataCadastro").IsModified = false;

            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
