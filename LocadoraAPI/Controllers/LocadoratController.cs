using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocadoraController : ControllerBase
    {
        public LocadoraController()
        {

        }

        [HttpGet("filmes")]
        public ActionResult<List<Filme>> ObterFilmes()
        {
            return new List<Filme>();
        }

        [HttpPost("filmes")]
        public ActionResult<Filme> CadastrarFilme()
        {
            return new Filme();
        }

        [HttpGet("clientes")]
        public ActionResult<List<Cliente>> ObterClientes()
        {
            return new List<Cliente>();
        }

        [HttpPost("clientes")]
        public ActionResult<Cliente> CadastrarCliente()
        {
            return new Cliente();
        }

        [HttpGet("locacoes")]
        public ActionResult<List<Locacao>> ObterLocacoes()
        {
            return new List<Locacao>();
        }

        [HttpGet("locacoes")]
        public ActionResult<Locacao> CadastrarLocacao()
        {
            return new Locacao();
        }

        [HttpDelete("locacoes")]
        public ActionResult<bool> DevolverLocacao()
        {
            return true;
        }
    }
}