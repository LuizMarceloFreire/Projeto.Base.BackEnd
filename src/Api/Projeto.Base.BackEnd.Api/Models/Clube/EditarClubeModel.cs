using System.ComponentModel.DataAnnotations;

namespace Projeto.Base.BackEnd.Api.Models.Clube
{
    public class EditarClubeModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int AnoFundacao { get; set; }

        [Required]
        public string UrlRedeSocial { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
