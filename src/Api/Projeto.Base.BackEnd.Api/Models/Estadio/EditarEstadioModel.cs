using System.ComponentModel.DataAnnotations;

namespace Projeto.Base.BackEnd.Api.Models.Estadio
{
    public class EditarEstadioModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
