using System.ComponentModel.DataAnnotations;

namespace DesafioBackEndEBH2022.Models
{
    public class LoginRequisicaoModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
