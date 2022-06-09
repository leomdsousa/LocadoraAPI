using LocadoraAPI.DTOs;
using LocadoraAPI.Services.Interfaces;
using LocadoraAPI.Utils;
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
        public ActionResult<RetornoAPI> ObterFilmes()
        {
            var retorno = _filmeService.ObterFilmes();

            if (retorno?.Count == 0) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpGet("filmes/{idFilme}")]
        public ActionResult<RetornoAPI> ObterFilmes(int idFilme)
        {
            var retorno = _filmeService.ObterFilme(idFilme);

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpPost("filmes")]
        public ActionResult<RetornoAPI> CadastrarFilme([FromBody] FilmeDTO dto)
        {
            var retorno = _filmeService.CadastrarFilme(dto);

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpGet("clientes")]
        public ActionResult<RetornoAPI> ObterClientes()
        {
            var retorno = _clienteService.ObterClientes();

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpGet("clientes/{idCliente}")]
        public ActionResult<RetornoAPI> ObterClientes(int idCliente)
        {
            var retorno = _clienteService.ObterCliente(idCliente);

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpPost("clientes")]
        public ActionResult<RetornoAPI> CadastrarCliente([FromBody] ClienteDTO dto)
        {
            var retorno = _clienteService.CadastrarCliente(dto);

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpGet("locacoes")]
        public ActionResult<RetornoAPI> ObterLocacoes()
        {
            var retorno = _locacaoService.ObterLocacoes();

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpGet("locacoes/{idLocacao}")]
        public ActionResult<RetornoAPI> ObterLocacoes(int idLocacao)
        {
            var retorno = _locacaoService.ObterLocacao(idLocacao);

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = null
            };
        }

        [HttpPost("locacoes")]
        public ActionResult<RetornoAPI> LocarFilme([FromBody] LocacaoDTO dto)
        {
            var retorno = _locacaoService.LocarFilme(dto);

            if (retorno is null) return NoContent();

            return new RetornoAPI()
            {
                Dados = new
                {
                    retorno.IdLocacao,
                    retorno.Filme,
                    retorno.Cliente,
                    retorno.EmAtraso,
                    retorno.DataLocacao,
                    retorno.DataDevolucao
                    retorno.Ativo
                },
                Mensagem = null
            };
        }

        [HttpDelete("locacoes/{idLocacao}")]
        public ActionResult<RetornoAPI> DevolverFilme(int idLocacao)
        {
            var mensagemRetorno = null as string;

            var retorno = _locacaoService.DevolverFilme(idLocacao, out mensagemRetorno);

            return new RetornoAPI()
            {
                Dados = retorno,
                Mensagem = mensagemRetorno
            };
        }
    }
}