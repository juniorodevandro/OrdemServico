using Microsoft.EntityFrameworkCore;
using OrdemServico.Api.Entities;
using OrdemServico.Api.Interface;
using OrdemServico.Data;

namespace OrdemServico.Api.Repository
{
    public class ServicoOrdemRepository : IServicoOrdem
    {
        private readonly AppDbContext _context;

        public ServicoOrdemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServicoOrdem>> GetServico(int? codigoOrdem, string? nomeProduto, int? situacao)
        {
            return Enumerable.Empty<ServicoOrdem>();
        }
    }


}
