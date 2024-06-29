using System.Text.Json.Serialization;

namespace OrdemServico.Models.DTO
{
    public class OrdemDTO
    {
        public required int Codigo { get; set; }

        public required DateTime Data { get; set; }

        public decimal ValorLiquido { get; set; }

        public decimal ValorBruto { get; set; }

        public decimal QuantidadeProduto { get; set; }

        public int? Desconto { get; set; }

        public string? Observacao { get; set; }

        public string? NumeroControle { get; set; }

        [JsonIgnore]
        public int TipoId { get; set; }
        public required string TipoNome { get; set; }

        [JsonIgnore]
        public int ClienteId { get; set; }
        public required string ClienteNome { get; set; }

        [JsonIgnore]
        public int SituacaoId { get; set; }
        public required string SituacaoNome { get; set; }
    }
}
