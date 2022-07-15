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
    public class EstoqueController : ControllerBase
    {
        private readonly DesafioContext _context;

        private readonly ILogger<EstoqueController> _logger;

        public EstoqueController(ILogger<EstoqueController> logger, DesafioContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("ObterEstoques")]
        public async Task<IEnumerable<ItemEstoque>> Get()
        {
            return await _context.ItemEstoques.ToArrayAsync();
        }

        [HttpGet("ObterEstoquePorIdProduto")]
        public async Task<ItemEstoque> Get([FromQuery] int id)
        {
            return await _context.ItemEstoques.SingleAsync(x => x.ProdutoId == id);
        }

        [HttpPost()]
        public void Post([FromBody] ItemEstoque itemEstoque)
        {
            _context.ItemEstoques.Add(itemEstoque);
            _context.SaveChanges();
        }

        [HttpPut()]
        public void Put([FromBody] ItemEstoque itemEstoque)
        {
            _context.ItemEstoques.Update(itemEstoque);
            _context.SaveChanges();
        }

        [HttpPatch()]
        public async void Patch([FromQuery] int produtoId, int lojaId, int quantidade, bool adicionarEstoque)
        {
            var itemEstoque = await _context.ItemEstoques.SingleAsync(x => x.ProdutoId == produtoId && x.LojaId == lojaId);

            if (adicionarEstoque)
                itemEstoque.QuantidadeEstoque = itemEstoque.QuantidadeEstoque + quantidade;
            else
                itemEstoque.QuantidadeEstoque = itemEstoque.QuantidadeEstoque - quantidade;

            _context.ItemEstoques.Update(itemEstoque);
            _context.SaveChanges();
        }
    }
}