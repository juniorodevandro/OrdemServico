using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Api.Entities
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O campo 'Código' é obrigatório")]
        public int Codigo { get; set; }

        [StringLength(150, ErrorMessage = "O campo nome deve ter no máximo 150 caracteres")]
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo 'CPF/CNPJ' é obrigatório")]
        public string? CpfCnpj { get; set; }

        public string? Contato { get; set; }

        [Required(ErrorMessage = "O campo 'Tipo' é obrigatório")]
        public int TipoId { get; set; }

        [ForeignKey("TipoId")]
        public required TipoPessoa Tipo { get; set; }

        [Required(ErrorMessage = "O campo 'Situação' é obrigatório")]
        public int SituacaoId { get; set; }

        [ForeignKey("SituacaoId")]
        public required Situacao Situacao { get; set; }

        [JsonIgnore]
        public ICollection<Ordem> Ordem { get; set; } = [];
    }
}
