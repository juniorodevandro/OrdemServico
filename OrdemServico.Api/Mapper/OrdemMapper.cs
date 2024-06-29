using OrdemServico.Api.Entities;
using OrdemServico.Api.Mappings;
using OrdemServico.Models.DTO;

namespace OrdemServico.Api
{
    public class OrdemMapper : BaseMapper
    {
        public OrdemMapper()
        {
            CreateMap<Ordem, OrdemDTO>()
                .ForMember(dest => dest.TipoNome, opt => opt.MapFrom(src => src.Tipo.Nome))
                .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));
        }
    }
}