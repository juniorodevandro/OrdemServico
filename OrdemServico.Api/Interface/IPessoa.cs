using OrdemServico.Api.Entities;
using OrdemServico.Models.DTO;

namespace OrdemServico.Api.Interface
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetPessoa(int? codigo, string? cpfCnpj, string? nome, string? tipo, int? situacao);

        Task<Pessoa> CadastrarPessoa(PessoaPostDTO pessoa);

        Task<bool> RemoverPessoa(int? codigo, string? cpfCnpj);

        Task<bool> AlterarPessoa(int? codigo, string? cpfCnpj, PessoaPutDTO pessoa);
    }
}
