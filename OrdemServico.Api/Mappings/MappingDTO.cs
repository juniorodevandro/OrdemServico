using AutoMapper;
using OrdemServico.Api.Entities;
using OrdemServico.Models.DTO;

namespace OrdemServico.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ordem, OrdemDTO>()
                .ForMember(dest => dest.TipoNome, opt => opt.MapFrom(src => src.Tipo.Nome))
                .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));

            CreateMap<Pessoa, PessoaDTO>()
                .ForMember(dest => dest.TipoNome, opt => opt.MapFrom(src => src.Tipo.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));

            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.TipoNome, opt => opt.MapFrom(src => src.Tipo.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));

            CreateMap<ServicoOrdem, ServicoOrdemDTO>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.Nome))
                .ForMember(dest => dest.SituacaoNome, opt => opt.MapFrom(src => src.Situacao.Nome));
        }
    }
} 