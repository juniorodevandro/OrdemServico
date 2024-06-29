using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Api.Entities
{
    [Table("Pessoa")]
    [Index(nameof(Codigo), IsUnique = true)]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Código' é obrigatório")]
        public int Codigo { get; set; }

        [StringLength(150, ErrorMessage = "O campo nome deve ter no máximo 150 caracteres")]
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo 'CPF/CNPJ' é obrigatório")]
        [RegularExpression(@"^(\d{3}\.\d{3}\.\d{3}-\d{2})|(\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2})$", ErrorMessage = "O CPF/CNPJ informado é inválido.")]
        public string? CpfCnpj { get; set; }

        public string? Contato { get; set; }

        [Required(ErrorMessage = "O campo 'Tipo' é obrigatório")]
        public int TipoId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public required TipoPessoa Tipo { get; set; }

        [Required(ErrorMessage = "O campo 'Situação' é obrigatório")]
        public int SituacaoId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public required Situacao Situacao { get; set; }

        public ICollection<Ordem> Ordem { get; set; } = [];
    }
}
