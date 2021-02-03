using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevIO.Data.Context;
using DevIO.Business.Models;
using DevIO.Business.Interfaces;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await DbSet.AsNoTracking().Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await DbSet.AsNoTracking().Include(f => f.Produtos).Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
