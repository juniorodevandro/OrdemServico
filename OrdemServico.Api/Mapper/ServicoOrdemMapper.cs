using OrdemServico.Api.Entities;
using OrdemServico.Api.Mappings;
using OrdemServico.Models.DTO;

namespace OrdemServico.Api
{
    public class ServicoOrdemMapper : BaseMapper
    {
        public ServicoOrdemMapper()
        {
            CreateMap<ServicoOrdem, ServicoOrdemDTO>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));
        }
    }
}