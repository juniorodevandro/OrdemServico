using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Api.Entities
{
    [Table("ServicoOrdem")]
    public class ServicoOrdem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Sequencial' é obrigatório")]
        public int Sequencial { get; set; }

        [Required(ErrorMessage = "O campo 'Produto' é obrigatório")]
        public int ProdutoId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public required Produto Produto { get; set; }
  
        [Required(ErrorMessage = "O campo 'Ordem de serviço' é obrigatório")]
        public int OrdemId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public required Ordem Ordem { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade' é obrigatório")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantidade { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorUnitario { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O campo 'Situação' é obrigatório")]
        public int SituacaoId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public required Situacao Situacao { get; set; }
    }
}
