using OrdemServico.Models.DTO;
using System.Net;
using System.Net.Http;
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
                    return await response.Content.ReadFromJsonAsync<IEnumerable<PessoaGetDTO>>() ?? Enumerable.Empty<PessoaGetDTO>();
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

        public async Task<PessoaGetDTO> AdicionarPessoa(PessoaPostDTO pessoa)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<PessoaPostDTO>("api/Pessoa/cadastrar", pessoa);

                if (response.IsSuccessStatusCode)// status code entre 200 a 299
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        // retorna o valor "padrão" ou vazio
                        // para uma objeto do tipo carrinhoItemDto
                        return default(PessoaGetDTO);
                    }
                    //le o conteudo HTTP e retorna o valor resultante
                    //da serialização do conteudo JSON para o objeto Dto
                    return await response.Content.ReadFromJsonAsync<PessoaGetDTO>();
                }
                else
                {
                    //serializa o conteudo HTTP como uma string
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception e)
            {
                throw new Exception(($"Erro {e.Message}"));
            }
        }
    }
}
