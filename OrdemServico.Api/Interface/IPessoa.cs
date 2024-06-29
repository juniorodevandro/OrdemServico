using OrdemServico.Api.Entities;

namespace OrdemServico.Api.Interface
{
    public interface IPessoa
    {
        Task<IEnumerable<Pessoa>> GetPessoa(int? codigo, string? cpfCnpj, string? nome, string? tipo, int? situacao);
    }
}
