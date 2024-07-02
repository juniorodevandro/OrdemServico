using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace OrdemServico.Models.DTO
{
    public class PessoaDTO
    {
        public required int Codigo { get; set; }

        public required string Nome { get; set; }

        public required string CpfCnpj { get; set; }

        public string? Contato { get; set; }

        public int TipoId { get; set; }
        public required string TipoNome { get; set; }

        public int SituacaoId { get; set; }
        public required string SituacaoNome { get; set; }
    }

    public class PessoaGetDTO
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("cpfCnpj")]
        public string CpfCnpj { get; set; } = string.Empty;

        public string Contato { get; set; } = string.Empty;

        [JsonPropertyName("tipo")]
        public string TipoNome { get; set; } = string.Empty;

        [JsonPropertyName("situacao")]
        public string SituacaoNome { get; set; } = string.Empty;
    }

    public class PessoaPostDTO
    {
        public required string Nome { get; set; }

        public required string CpfCnpj { get; set; }

        public string? Contato { get; set; }

        [JsonPropertyName("tipo")]
        public required string TipoNome { get; set; }
    }

    public class PessoaPutDTO
    {
        public required string Nome { get; set; }

        public string? Contato { get; set; }
    }
}
