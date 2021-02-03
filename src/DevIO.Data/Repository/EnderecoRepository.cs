using System;
using System.Threading.Tasks;
using DevIO.Data.Context;
using DevIO.Business.Models;
using DevIO.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
        }
    }
}
