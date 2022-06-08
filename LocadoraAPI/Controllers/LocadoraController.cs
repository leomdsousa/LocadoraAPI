using LocadoraAPI.DTOs;
using LocadoraAPI.Models;
using LocadoraAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class LocadoraController : ControllerBase
    {
        private IClienteService _clienteService;
        private IFilmeService _filmeService;
        private ILocacaoService _locacaoService;

        public LocadoraController(IClienteService clienteService, IFilmeService filmeService, ILocacaoService locacaoService)
        {
            _clienteService = clienteService;
            _filmeService = filmeService;
            _locacaoService = locacaoService;
        }

        [HttpGet("filmes")]
        public ActionResult<List<FilmeDTO>> ObterFilmes()
        {
            return _filmeService.ObterFilmes();
        }

        [HttpGet("filmes/{idFilme}")]
        public ActionResult<FilmeDTO> ObterFilmes(int idFilme)
        {
            return _filmeService.ObterFilme(idFilme);
        }

        [HttpPost("filmes")]
        public ActionResult<FilmeDTO> CadastrarFilme([FromBody] FilmeDTO dto)
        {
            return _filmeService.CadastrarFilme(dto);
        }

        [HttpGet("clientes")]
        public ActionResult<List<ClienteDTO>> ObterClientes()
        {
            return _clienteService.ObterClientes();
        }

        [HttpGet("clientes/{idCliente}")]
        public ActionResult<ClienteDTO> ObterClientes(int idCliente)
        {
            return _clienteService.ObterCliente(idCliente);
        }

        [HttpPost("clientes")]
        public ActionResult<ClienteDTO> CadastrarCliente([FromBody] ClienteDTO dto)
        {
            return _clienteService.CadastrarCliente(dto);
        }

        [HttpGet("locacoes")]
        public ActionResult<List<LocacaoDTO>> ObterLocacoes()
        {
            return _locacaoService.ObterLocacoes();
        }

        [HttpGet("locacoes/{idLocacao}")]
        public ActionResult<LocacaoDTO> ObterLocacoes(int idLocacao)
        {
            return _locacaoService.ObterLocacao(idLocacao);
        }

        [HttpPost("locacoes")]
        public ActionResult<LocacaoDTO> LocarFilme([FromBody] LocacaoDTO dto)
        {
            return _locacaoService.LocarFilme(dto);
        }

        [HttpDelete("locacoes/{idLocacao}")]
        public ActionResult<bool> DevolverFilme(int idLocacao)
        {
            return _locacaoService.DevolverFilme(idLocacao);
        }
    }
}