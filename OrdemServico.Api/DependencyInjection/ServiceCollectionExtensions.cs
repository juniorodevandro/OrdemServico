using OrdemServico.Api.Interface;
using OrdemServico.Api.Repository;

namespace OrdemServico.Api.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProduto, ProdutoRepository>();
            services.AddScoped<IPessoa, PessoaRepository>();
            services.AddScoped<IOrdem, OrdemRepository>();
            services.AddScoped<IServicoOrdem, ServicoOrdemRepository>();

            return services;
        }
    }
}
