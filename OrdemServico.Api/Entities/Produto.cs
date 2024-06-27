using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Api.Entities
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Código' é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Tipo' é obrigatório")]
        public int TipoId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public TipoProduto? Tipo { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O campo 'Situação' é obrigatório")]
        public int SituacaoId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Situacao? Situacao { get; set; }

        [JsonIgnore]
        public ICollection<ServicoOrdem> OrdemServico { get; set; } = [];
    }
}
