using OrdemServico.Api.Entities;

namespace OrdemServico.Api.Interface
{
    public interface IServicoOrdem
    {
        Task<IEnumerable<ServicoOrdem>> GetServico(int? codigoOrdem, string? nomeProduto, int? situacao);
    }
}
