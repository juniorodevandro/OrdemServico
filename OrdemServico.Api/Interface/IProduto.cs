using OrdemServico.Api.Entities;

namespace OrdemServico.Api.Interface
{
    public interface IProduto
    {
        Task<IEnumerable<Produto>> GetProduto(int? codigo, string? nome, string? tipo, int? situacao);
    }
}
