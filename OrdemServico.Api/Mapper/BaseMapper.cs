using AutoMapper;

namespace OrdemServico.Api.Mappings
{
    public partial class BaseMapper : Profile
    {
        public BaseMapper()
        {
            CreateMap<DateTime, string>().ConvertUsing(date => date.ToString("dd-MM-yyyy hh:mm"));
        }
    }
}