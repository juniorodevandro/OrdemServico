using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Api.Entities
{
    [Table("Situacao")]
    public class Situacao
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O campo 'Código' é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        public string? Icone { get; set; }

        public string? Observacao { get; set; }


        [JsonIgnore]
        public ICollection<ServicoOrdem> ServicoOrdem { get; set; } = [];

        [JsonIgnore]
        public ICollection<Ordem> Ordem { get; set; } = [];

        [JsonIgnore]
        public ICollection<Produto> Produto { get; set; } = [];        
        
        [JsonIgnore]
        public ICollection<Pessoa> Pessoa { get; set; } = [];

    }
}
