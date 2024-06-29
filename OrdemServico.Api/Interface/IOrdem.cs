using OrdemServico.Api.Entities;

namespace OrdemServico.Api.Interface
{
    public interface IOrdem
    {
        Task<IEnumerable<Ordem>> GetOrdem(int? codigo, string? numeroControle, string? cliente, string? tipo, int? situacao);
        Task<IEnumerable<Ordem>> GetOrdemServico(int? codigo, string? numeroControle, string? cliente, string? tipo, int? situacao);
    }
}
