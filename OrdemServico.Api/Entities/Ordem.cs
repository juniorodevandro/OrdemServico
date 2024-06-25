using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Api.Entities
{
    [Table("Ordem")]
    public class Ordem
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O campo 'Código' é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo 'Data' é obrigatório")]
        public DateTime Data { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorLiquido { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorBruto { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal QuantidadeProduto { get; set; }

        public int? Desconto { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O campo 'Tipo' é obrigatório")]
        public int TipoId { get; set; }

        [ForeignKey("TipoId")]
        public required TipoOrdem Tipo { get; set; }

        [Required(ErrorMessage = "O campo 'Cliente' é obrigatório")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public required Pessoa Cliente { get; set; }

        [Required(ErrorMessage = "O campo 'Situação' é obrigatório")]
        public int SituacaoId { get; set; }

        [ForeignKey("SituacaoId")]
        public required Situacao Situacao { get; set; }

        [JsonIgnore]
        public ICollection<ServicoOrdem> ServicoOrdem { get; set; } = [];
    }
}
