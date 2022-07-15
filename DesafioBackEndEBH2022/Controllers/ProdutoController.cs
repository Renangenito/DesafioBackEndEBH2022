using DesafioBackEndEBH2022.Dados;
using DesafioBackEndEBH2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEndEBH2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly DesafioContext _context;

        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger, DesafioContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("ObterTodosOsProdutos")]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _context.Produtos.ToArrayAsync();
        }

        [HttpGet("ObterProdutoPorId")]
        public async Task<Produto> Get([FromQuery] int id)
        {
            return await _context.Produtos.SingleAsync(x => x.Id == id);
        }

        [HttpPost()]
        public void Post([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        [HttpPut()]
        public void Put([FromBody] Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        [HttpDelete()]
        public async void Delete([FromQuery] int id)
        {
            var produto = await _context.Produtos.SingleAsync(x => x.Id == id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}