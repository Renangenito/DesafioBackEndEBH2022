using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackEndEBH2022.Models
{
    public class Loja
    {
        public Loja()
        {
            this.Produtos = new HashSet<Produto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome da Loja")]
        [Required(ErrorMessage = "Informe o nome da loja")]
        public string Nome { get; set; }

        [Display(Name = "Endereço da Loja")]
        [Required(ErrorMessage = "Informe o endereço da loja")]
        public string Endereco { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}
