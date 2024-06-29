﻿using System.Text.Json.Serialization;

namespace OrdemServico.Models.DTO
{
    public class PessoaDTO
    {
        public required int Codigo { get; set; }

        public required string Nome { get; set; }

        public required string CpfCnpj { get; set; }

        public string? Contato { get; set; }

        public int TipoId { get; set; }
        public required string TipoNome { get; set; }

        public int SituacaoId { get; set; }
        public required string SituacaoNome { get; set; }
    }

    public class PessoaGetDTO
    {
        public required int Codigo { get; set; }

        public required string Nome { get; set; }

        public required string CpfCnpj { get; set; }

        public string? Contato { get; set; }

        [JsonPropertyName("tipo")]
        public required string TipoNome { get; set; }

        [JsonPropertyName("situacao")]
        public required string SituacaoNome { get; set; }
    }

    public class PessoaPostDTO
    {
        public required string Nome { get; set; }

        public required string CpfCnpj { get; set; }

        public string? Contato { get; set; }

        [JsonPropertyName("tipo")]
        public required string TipoNome { get; set; }
    }
}
