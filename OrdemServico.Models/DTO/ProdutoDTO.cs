using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Models.DTO
{
    public class ProdutoDTO
    {     
        public required int Codigo { get; set; }

        public required string Nome { get; set; }

        public int TipoId { get; set; }
        public required int TipoNome { get; set; }

        public string? Observacao { get; set; }

        public int SituacaoId { get; set; }
        public required string SituacaoNome { get; set; }
    }
}
