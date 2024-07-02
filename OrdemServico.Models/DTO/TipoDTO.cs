using System.Text.Json.Serialization;

namespace OrdemServico.Models.DTO
{
    public class TipoDTO
    {
        public required int Id { get; set; }

        public required int Codigo { get; set; }

        public int Nome { get; set; }      
    }
}
