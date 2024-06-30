using OrdemServico.Api.Entities;
using OrdemServico.Api.Mappings;
using OrdemServico.Models.DTO;

namespace OrdemServico.Api
{
    public class ProdutoMapper : BaseMapper
    {
        public ProdutoMapper()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.TipoNome, opt => opt.MapFrom(src => src.Tipo.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));

            CreateMap<Pessoa, PessoaGetDTO>()
                .ForMember(dest => dest.TipoNome, opt => opt.MapFrom(src => src.Tipo.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));

            CreateMap<PessoaPostDTO, PessoaGetDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.Ignore())
                .ForMember(dest => dest.TipoNome, opt => opt.MapFrom(src => src.TipoNome));
        }
    }
}