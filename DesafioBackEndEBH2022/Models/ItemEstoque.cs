using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackEndEBH2022.Models
{
    public class ItemEstoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Id do Produto")]
        [Required(ErrorMessage = "Informe Id da Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Id da Loja")]
        [Required(ErrorMessage = "Informe Id da Loja")]
        public int LojaId { get; set; }

        [Display(Name = "Quantidade Estoque")]
        [Required(ErrorMessage = "Informe a quantidade em estoque")]
        public int QuantidadeEstoque { get; set; }

        public Loja Loja { get; set; }
        public Produto Produto { get; set; }
    }
}
