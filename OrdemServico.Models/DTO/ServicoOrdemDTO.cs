using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Models.DTO
{
    public class ServicoOrdemDTO
    {
        public required int Sequencial { get; set; }

        public int ProdutoId { get; set; }        
        public required string ProdutoNome { get; set; }

        public int OrdemId { get; set; }
        public required int OrdemCodigo { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }

        public string? Observacao { get; set; }

        public int SituacaoId { get; set; }
        public required string SituacaoNome { get; set; }
    }
}
