using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdemServico.Api.Entities
{
    [Table("Situacao")]
    [Index(nameof(Codigo), IsUnique = true)]
    public class Situacao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Código' é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        public string? Icone { get; set; }

        public string? Observacao { get; set; }

        public ICollection<Ordem> Ordem { get; set; } = [];

        public ICollection<ServicoOrdem> ServicoOrdem { get; set; } = [];

        public ICollection<Pessoa> Pessoa { get; set; } = [];

        public ICollection<Produto> Produto { get; set; } = [];
    }
}
