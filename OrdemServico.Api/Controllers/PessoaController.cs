using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrdemServico.Api.Interface;
using OrdemServico.Models.DTO;

namespace OrdemServico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {       
        private readonly IPessoaRepository _Pessoa;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaRepository pessoaRepository, IMapper mapper)
        {
                _Pessoa = pessoaRepository;
                _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoa([FromQuery] int? codigo, string? cpfCnpj, string? nome, string? tipo, int? situacao)
        {
            try
            {
                var pessoas = await _Pessoa.GetPessoa(codigo, cpfCnpj, nome, tipo, situacao);

                if (!pessoas.Any())
                {
                    return BadRequest("Pessoa não encontrada.");
                }
                else
                {
                    // Converter IEnumerable<PessoaDTO> para IEnumerable<PessoaGetDTO>
                    var pessoaDTO = _mapper.Map<IEnumerable<PessoaGetDTO>>(pessoas);

                    return Ok(pessoaDTO);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CriarPessoa([FromBody] PessoaPostDTO pessoaPostDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pessoa = await _Pessoa.CadastrarPessoa(pessoaPostDTO);

                if (pessoa != null)
                {
                    var pessoaGetDTO = _mapper.Map<PessoaGetDTO>(pessoa);

                    var resultado = new
                    {
                        Message = "Registro cadastrado com sucesso",
                        Codigo = pessoaGetDTO.Codigo,
                        Nome = pessoaGetDTO.Nome
                    };

                    return Ok(resultado);
                }
                else
                {
                    return BadRequest("Pessoa não cadastrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Erro ao cadastrar pessoa", erro = e.Message });
            }
        }
    }
}
