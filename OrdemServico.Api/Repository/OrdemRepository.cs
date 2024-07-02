using Microsoft.EntityFrameworkCore;
using OrdemServico.Api.Entities;
using OrdemServico.Api.Interface;
using OrdemServico.Data;

namespace OrdemServico.Api.Repository
{
    public class OrdemRepository : IOrdem
    {
        private readonly AppDbContext _context;

        public OrdemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ordem>> GetOrdem(int? codigo, string? numeroControle, string? cliente, string? tipo, int? situacao)
        {
            return Enumerable.Empty<Ordem>(); 
        }

        public async Task<IEnumerable<Ordem>> GetOrdemServico(int? codigo, string? numeroControle, string? cliente, string? tipo, int? situacao)
        {
            return Enumerable.Empty<Ordem>();
        }
    }


}
