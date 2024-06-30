using OrdemServico.Models.DTO;
using System.Net;
using System.Net.Http.Json;

namespace OrdemServico.Web.Services
{
    public class PessoaService : IPessoa
    {
        public HttpClient _httpClient;
        public ILogger<PessoaService> _logger;

        public PessoaService(HttpClient httpClient,
            ILogger<PessoaService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<PessoaGetDTO>> GetPessoa()
        {
            try
            {
                HttpResponseMessage response;
             
                response = await _httpClient.GetAsync($"api/Pessoa/buscar");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<PessoaGetDTO>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<PessoaGetDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro a obter produto pelo id - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro {ex.Message}");
                throw new Exception(($"Erro {ex.Message}"));
            }
        }
    }
}
