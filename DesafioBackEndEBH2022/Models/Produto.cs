using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackEndEBH2022.Models
{
    public class Produto
    {
        public Produto()
        {
            this.Lojas = new HashSet<Loja>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [Display(Name = "Preço de Custo")]
        [Required(ErrorMessage = "Informe o Preço de Custo do produto")]
        [Precision(18, 2)]
        public decimal PrecoCusto { get; set; }

        public virtual ICollection<Loja> Lojas { get; set; }
    }
}
