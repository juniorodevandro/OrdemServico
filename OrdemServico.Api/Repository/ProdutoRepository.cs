using Microsoft.EntityFrameworkCore;
using OrdemServico.Api.Entities;
using OrdemServico.Api.Interface;
using OrdemServico.Data;

namespace OrdemServico.Api.Repository
{
    public class ProdutoRepository : IProduto
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetProduto(int? codigo, string? nome, string? tipo, int? situacao)
        {
            return Enumerable.Empty<Produto>();
        }
    }


}
