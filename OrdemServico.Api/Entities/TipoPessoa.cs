﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServico.Api.Entities
{
    [Table("TipoPessoa")]
    public class TipoPessoa
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O campo 'Código' é obrigatório")]
        public int Codigo { get; set; }

        [StringLength(150, ErrorMessage = "O campo nome deve ter no máximo 150 caracteres")]
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string? Nome { get; set; }

        public string? Observacao { get; set; }

        [JsonIgnore]
        public ICollection<Pessoa> Pessoa { get; set; } = [];
    }
}
