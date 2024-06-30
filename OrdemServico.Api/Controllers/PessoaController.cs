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
        [Route("buscar")]
        public async Task<IActionResult> GetPessoa([FromQuery] int? codigo, string? cpfCnpj, string? nome, string? tipo, int? situacao)
        {
            try
            {
                var pessoas = await _Pessoa.GetPessoa(codigo, cpfCnpj, nome, tipo, situacao);

                if (!pessoas.Any())
                {
                    return NotFound("Pessoa não encontrada.");
                }
                else
                {
                    var pessoaDTO = _mapper.Map<IEnumerable<PessoaGetDTO>>(pessoas);

                    return Ok(pessoaDTO);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Erro ao buscar pessoa", erro = e.Message });
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
                    return NotFound(ModelState);
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

        [HttpDelete]
        [Route("remover")]
        public async Task<IActionResult> RemoverPessoa([FromQuery] int? codigo, string? cpfcnpj)
        {
            if (codigo == 0 || String.IsNullOrEmpty(cpfcnpj))
            {
                return BadRequest("Informe ao menos um parâmetro: 'Código' ou 'CpfCpnj'.");
            }

            try
            {
                var pessoa = await _Pessoa.RemoverPessoa(codigo, cpfcnpj);

                if (pessoa)
                    return Ok($"Pessoa removida com sucesso!");
                else
                    return BadRequest("Pessoa não removida.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Erro ao remover pessoa", erro = e.Message });
            }
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<IActionResult> AlterarPessoa([FromQuery] int? codigo, string? cpfcnpj, [FromBody] PessoaPutDTO pessoa)
        {
            if (codigo == 0 || String.IsNullOrEmpty(cpfcnpj))
            {
                return BadRequest("Informe ao menos um parâmetro: 'Código' ou 'CpfCpnj'.");
            }

            try
            {
                var pessoaAlterada = await _Pessoa.AlterarPessoa(codigo, cpfcnpj, pessoa);

                if (pessoaAlterada)
                    return Ok($"Pessoa alterada com sucesso. Codigo: {codigo}");
                else
                    return BadRequest("Pessoa não alterada.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Erro ao alterar pessoa", erro = e.Message });
            }
        }
    }
}
