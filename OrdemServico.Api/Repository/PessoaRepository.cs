using Microsoft.EntityFrameworkCore;
using OrdemServico.Api.Entities;
using OrdemServico.Api.Interface;
using OrdemServico.Data;

namespace OrdemServico.Api.Repository
{
    public class PessoaRepository : IPessoa
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoa(int? codigo, string? cpfCnpj, string? nome, string? tipo, int? situacao)
        {
            return Enumerable.Empty<Pessoa>();
        }
    }


}
