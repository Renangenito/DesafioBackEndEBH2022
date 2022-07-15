using DesafioBackEndEBH2022.Models;

namespace DesafioBackEndEBH2022.Dados
{
    public class DadosSemente
    {
        public static void Criar(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DesafioContext>();

                if (!context.Produtos.Any())
                {
                    context.Produtos.AddRange(
                        new Produto() { Id = 0, Nome = "Produto 1", PrecoCusto = 10 },
                        new Produto() { Id = 0, Nome = "Produto 2", PrecoCusto = 100 });

                    context.Lojas.AddRange(
                        new Loja() { Id = 0, Nome = "Loja 1", Endereco = "Endereço 1" },
                        new Loja() { Id = 0, Nome = "Loja 2", Endereco = "Endereço 2" });

                    context.ItemEstoques.AddRange(
                        new ItemEstoque() { Id = 0, LojaId = 1, ProdutoId = 1, QuantidadeEstoque = 11 },
                        new ItemEstoque() { Id = 0, LojaId = 1, ProdutoId = 2, QuantidadeEstoque = 12 },
                        new ItemEstoque() { Id = 0, LojaId = 2, ProdutoId = 1, QuantidadeEstoque = 21 },
                        new ItemEstoque() { Id = 0, LojaId = 2, ProdutoId = 2, QuantidadeEstoque = 22 },

                        new ItemEstoque() { Id = 0, LojaId = 55, ProdutoId = 55, QuantidadeEstoque = 55 }
                        );

                    context.SaveChanges();
                }
            }
        }
    }
}
