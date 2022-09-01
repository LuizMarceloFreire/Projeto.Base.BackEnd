using System.ComponentModel.DataAnnotations;

namespace Projeto.Base.BackEnd.Api.Models.Clube
{
    public class CadastrarClubeModel
    {
        public int EstadioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int AnoFundacao { get; set; }

        [Required]
        public string UrlRedeSocial { get; set; }
    }
}
