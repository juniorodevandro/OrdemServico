using OrdemServico.Models.DTO;

namespace OrdemServico.Web.Services
{
    public interface IPessoa
    {
        Task<IEnumerable<PessoaGetDTO>> GetPessoa();
    }
}