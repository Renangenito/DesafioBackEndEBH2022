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
    public class LojaController : ControllerBase
    {
        private readonly DesafioContext _context;

        private readonly ILogger<LojaController> _logger;

        public LojaController(ILogger<LojaController> logger, DesafioContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("ObterTodasAsLojas")]
        public async Task<IEnumerable<Loja>> Get()
        {
            var query = await _context.Lojas.ToArrayAsync();
            return query;
        }

        [HttpGet("ObterLojaPorId")]
        public async Task<Loja> Get([FromQuery] int id)
        {
            return await _context.Lojas.SingleAsync(x => x.Id == id);
        }

        [HttpPost()]
        public void Post([FromBody] Loja loja)
        {
            _context.Lojas.Add(loja);
            _context.SaveChanges();
        }

        [HttpPut()]
        public void Put([FromBody] Loja loja)
        {
            _context.Lojas.Update(loja);
            _context.SaveChanges();
        }

        [HttpDelete()]
        public async void Delete([FromQuery] int id)
        {
            var loja = await _context.Lojas.SingleAsync(x => x.Id == id);
            _context.Lojas.Remove(loja);
            _context.SaveChanges();
        }
    }
}