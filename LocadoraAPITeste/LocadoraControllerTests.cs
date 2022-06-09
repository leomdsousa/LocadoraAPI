using LocadoraAPI.Controllers;
using LocadoraAPI.DTOs;
using LocadoraAPI.Models;
using LocadoraAPI.Services;
using LocadoraAPI.Utils;
using LocadoraAPITeste.Mock;
using Moq;

namespace LocadoraAPITeste
{
    public class LocadoraControllerTests
    {
        private readonly ClienteService _clienteService;
        private readonly FilmeService _filmeService;
        private readonly LocacaoService _locacaoService;
        private readonly LocadoraController _controller;
        private readonly LocadoraAPITesteMock _mock;

        public LocadoraControllerTests()
        {
            _mock = new LocadoraAPITesteMock();
            _clienteService = new ClienteService(_mock.ClienteRepository.Object);
            _filmeService = new FilmeService(_mock.FilmeRepository.Object);
            _locacaoService = new LocacaoService(_mock.LocacaoRepository.Object);
            _controller = new LocadoraController(_clienteService, _filmeService, _locacaoService);
        }

        [Fact]
        public void TestarObterClientes()
        {
            //arrange
            _mock.ClienteRepository.Setup(x => x.ObterClientes()).Returns(this.ObterClientes());
            _mock.ClienteService.Setup(x => x.ObterClientes()).Returns(this.ObterClientesDTO());

            //act
            var result = _controller.ObterClientes();

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotEmpty((List<ClienteDTO>)result.Value.Dados);
        }

        [Fact]
        public void TestarObterClientesPorId()
        {
            //arrange
            var idCliente = 1;

            _mock.ClienteRepository.Setup(x => x.ObterCliente(idCliente)).Returns(this.ObterCliente());
            _mock.ClienteService.Setup(x => x.ObterCliente(idCliente)).Returns(this.ObterClienteDTO());

            //act
            var result = _controller.ObterClientes(idCliente);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((ClienteDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarCliente()
        {
            //arrange
            var dto = new ClienteDTO()
            {
                IdCliente = 0,
                NomeCliente = "Leonardo Monteiro de Sousa",
                Ativo = true
            };

            _mock.ClienteRepository.Setup(x => x.CadastrarCliente(It.IsAny<Cliente>())).Returns(this.ObterCliente());
            _mock.ClienteService.Setup(x => x.CadastrarCliente(dto)).Returns(this.ObterClienteDTO());

            //act
            var result = _controller.CadastrarCliente(dto);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((ClienteDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarClienteExistente()
        {
            //arrange
            var dto = new ClienteDTO()
            {
                IdCliente = 0,
                NomeCliente = "Leonardo Monteiro de Sousa",
                Ativo = true
            };

            _mock.ClienteRepository.Setup(x => x.CadastrarCliente(It.IsAny<Cliente>())).Returns(this.ObterCliente());
            _mock.ClienteRepository.Setup(x => x.ExisteCliente(dto.NomeCliente)).Returns(true);
            _mock.ClienteService.Setup(x => x.CadastrarCliente(dto)).Returns(this.ObterClienteDTO());

            //act and assert
            var exception = Assert.Throws<InvalidOperationException>(() => _controller.CadastrarCliente(dto));
            Assert.Equal("Já existe usuário cadastrado com o mesmo nome.", exception.Message);
        }

        [Fact]
        public void TestarObterFilmes()
        {
            //arrange
            _mock.FilmeRepository.Setup(x => x.ObterFilmes()).Returns(this.ObterFilmes());
            _mock.FilmeService.Setup(x => x.ObterFilmes()).Returns(this.ObterFilmesDTO());

            //act
            var result = _controller.ObterFilmes();

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotEmpty((List<FilmeDTO>)result.Value.Dados);
        }

        [Fact]
        public void TestarObterFilmesPorId()
        {
            //arrange
            var idFilme = 1;

            _mock.FilmeRepository.Setup(x => x.ObterFilme(idFilme)).Returns(this.ObterFilme());
            _mock.FilmeService.Setup(x => x.ObterFilme(idFilme)).Returns(this.ObterFilmeDTO());

            //act
            var result = _controller.ObterFilmes(idFilme);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((FilmeDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarFilme()
        {
            //arrange
            var dto = new FilmeDTO()
            {
                IdFilme = 0,
                NomeFilme = "O Poderoso Chefão",
                Ativo = true
            };

            _mock.FilmeRepository.Setup(x => x.CadastrarFilme(It.IsAny<Filme>())).Returns(this.ObterFilme());
            _mock.FilmeService.Setup(x => x.CadastrarFilme(dto)).Returns(this.ObterFilmeDTO());

            //act
            var result = _controller.CadastrarFilme(dto);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((FilmeDTO)result.Value.Dados);
        }

        [Fact]
        public void TestarObterLocacoes()
        {
            //arrange
            _mock.LocacaoRepository.Setup(x => x.ObterLocacoes()).Returns(this.ObterLocacoes());
            _mock.LocacaoService.Setup(x => x.ObterLocacoes()).Returns(this.ObterLocacoesDTOOutput());

            //act
            var result = _controller.ObterLocacoes();

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotEmpty((List<LocacaoDTOOutput>)result.Value.Dados);
        }

        [Fact]
        public void TestarObterLocacaoPorId()
        {
            //arrange
            var idLocacao = 1;

            _mock.LocacaoRepository.Setup(x => x.ObterLocacao(idLocacao)).Returns(this.ObterLocacao());
            _mock.LocacaoService.Setup(x => x.ObterLocacao(idLocacao)).Returns(this.ObterLocacaoDTOOutput());

            //act
            var result = _controller.ObterLocacoes(idLocacao);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((LocacaoDTOOutput)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarLocacao()
        {
            //arrange
            var dto = new LocacaoDTOInput()
            {
                IdLocacao = 0,
                IdFilme = 1,
                IdCliente = 1
            };

            _mock.LocacaoRepository.Setup(x => x.LocarFilme(It.IsAny<Locacao>())).Returns(this.ObterLocacao());
            _mock.LocacaoRepository.Setup(x => x.ValidarDisponibilidadeFilme(dto.IdFilme)).Returns(true);
            _mock.LocacaoService.Setup(x => x.LocarFilme(dto)).Returns(this.ObterLocacaoDTOOutput());

            //act
            var result = _controller.LocarFilme(dto);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull((LocacaoDTOOutput)result.Value.Dados);
        }

        [Fact]
        public void TestarCadastrarLocacaoNaoDisponivel()
        {
            //arrange
            var dto = new LocacaoDTOInput()
            {
                IdLocacao = 0,
                IdFilme = 1,
                IdCliente = 1
            };

            _mock.LocacaoRepository.Setup(x => x.LocarFilme(It.IsAny<Locacao>())).Returns(this.ObterLocacao());
            _mock.LocacaoRepository.Setup(x => x.ValidarDisponibilidadeFilme(dto.IdFilme)).Returns(false);
            _mock.LocacaoService.Setup(x => x.LocarFilme(dto)).Returns(this.ObterLocacaoDTOOutput());

            //act and assert
            var exception = Assert.Throws<InvalidOperationException>(() => _controller.LocarFilme(dto));
            Assert.Equal("Filme não disponível para locação.", exception.Message);
        }

        [Fact]
        public void TestarDevolverLocacao()
        {
            //arrange
            var idLocacao = 1;
            string msgRetornoLocacao = null as string;

            _mock.LocacaoRepository.Setup(x => x.DevolverFilme(It.IsAny<Locacao>())).Returns(this.ObterLocacao());
            _mock.LocacaoRepository.Setup(x => x.ObterLocacao(idLocacao)).Returns(this.ObterLocacao());
            _mock.LocacaoService.Setup(x => x.DevolverFilme(idLocacao, out msgRetornoLocacao)).Returns(true);

            //act
            var result = _controller.DevolverFilme(idLocacao);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.True((bool)result.Value.Dados);
        }

        [Fact]
        public void TestarDevolverLocacaoComAtraso()
        {
            //arrange
            var idLocacao = 1;
            string msgRetornoLocacao = null as string;

            _mock.LocacaoRepository.Setup(x => x.DevolverFilme(It.IsAny<Locacao>())).Returns(this.ObterLocacao());
            _mock.LocacaoRepository.Setup(x => x.ObterLocacao(idLocacao)).Returns(this.ObterLocacaoEmAtraso());
            _mock.LocacaoService.Setup(x => x.DevolverFilme(idLocacao, out msgRetornoLocacao)).Returns(true);

            //act
            var result = _controller.DevolverFilme(idLocacao);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.True((bool)result.Value.Dados);
            Assert.Equal("Filme devolvido com atraso.", result.Value.Mensagem);
        }


        #region MÉTODOS AUXILIARES

        private ClienteDTO ObterClienteDTO()
        {
            return new ClienteDTO()
            {
                IdCliente = 1,
                NomeCliente = "Leonardo Monteiro de Sousa",
                Ativo = true
            };
        }

        private List<ClienteDTO> ObterClientesDTO()
        {
            return new List<ClienteDTO>()
            {
                new ClienteDTO()
                {
                    IdCliente = 1,
                    NomeCliente = "Garrincha",
                    Ativo = true
                },
                new ClienteDTO()
                {
                    IdCliente = 2,
                    NomeCliente = "Pelé",
                    Ativo = true
                },
            };
        }

        private Cliente ObterCliente()
        {
            return new Cliente()
            {
                IdCliente = 1,
                NomeCliente = "Leonardo Monteiro de Sousa",
                Ativo = 1
            };
        }

        private List<Cliente> ObterClientes()
        {
            return new List<Cliente>()
            {
                new Cliente()
                {
                    IdCliente = 1,
                    NomeCliente = "Garrincha",
                    Ativo = 1
                },
                new Cliente()
                {
                    IdCliente = 2,
                    NomeCliente = "Pelé",
                    Ativo = 1
                },
            };
        }

        private FilmeDTO ObterFilmeDTO()
        {
            return new FilmeDTO()
            {
                IdFilme = 1,
                NomeFilme = "O Poderoso Chefão",
                Ativo = true
            };
        }

        private List<FilmeDTO> ObterFilmesDTO()
        {
            return new List<FilmeDTO>()
            {
                new FilmeDTO()
                {
                    IdFilme = 1,
                    NomeFilme = "O Poderoso Chefão",
                    Ativo = true
                },
                new FilmeDTO()
                {
                    IdFilme = 2,
                    NomeFilme = "Jurassic Park",
                    Ativo = true
                },
            };
        }

        private Filme ObterFilme()
        {
            return new Filme()
            {
                IdFilme = 1,
                NomeFilme = "Leonardo Monteiro de Sousa",
                Ativo = 1
            };
        }

        private List<Filme> ObterFilmes()
        {
            return new List<Filme>()
            {
                new Filme()
                {
                    IdFilme = 1,
                    NomeFilme = "Garrincha",
                    Ativo = 1
                },
                new Filme()
                {
                    IdFilme = 2,
                    NomeFilme = "Pelé",
                    Ativo = 1
                },
            };
        }

        private LocacaoDTOInput ObterLocacaoDTOInput()
        {
            return new LocacaoDTOInput()
            {
                IdLocacao = 1,
                IdFilme = 1,
                IdCliente = 1
            };
        }

        private List<LocacaoDTOInput> ObterLocacoesDTOInput()
        {
            return new List<LocacaoDTOInput>()
            {
                new LocacaoDTOInput()
                {
                    IdLocacao = 1,
                    IdFilme = 1,
                    IdCliente = 1
                },
                new LocacaoDTOInput()
                {
                    IdLocacao = 1,
                    IdFilme = 2,
                    IdCliente = 1
                },
            };
        }

        private LocacaoDTOOutput ObterLocacaoDTOOutput()
        {
            return new LocacaoDTOOutput()
            {
                IdLocacao = 1,
                IdFilme = 1,
                Filme = "O Poderoso Chefão",
                IdCliente = 1,
                Cliente = "Leonardo Monteiro de Sousa",
                DataLocacao = DateTime.Now.ToString("dd/MM/yyyy"),
                DataDevolucao = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
                EmAtraso = false,
                Ativo = true
            };
        }

        private List<LocacaoDTOOutput> ObterLocacoesDTOOutput()
        {
            return new List<LocacaoDTOOutput>()
            {
                new LocacaoDTOOutput()
                {
                    IdLocacao = 1,
                    IdFilme = 1,
                    Filme = "O Poderoso Chefão",
                    IdCliente = 1,
                    Cliente = "Leonardo Monteiro de Sousa",
                    DataLocacao = DateTime.Now.ToString("dd/MM/yyyy"),
                    DataDevolucao = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
                    EmAtraso = false,
                    Ativo = true
                },
                new LocacaoDTOOutput()
                {
                    IdLocacao = 2,
                    IdFilme = 2,
                    Filme = "Jurassic Park",
                    IdCliente = 2,
                    Cliente = "Pelé",
                    DataLocacao = DateTime.Now.ToString("dd/MM/yyyy"),
                    DataDevolucao = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
                    EmAtraso = false,
                    Ativo = true
                },
            };
        }

        private Locacao ObterLocacao()
        {
            return new Locacao()
            {
                IdLocacao = 1,
                IdFilme = 1,
                IdCliente = 1,
                DataLocacao = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(7),
                EmAtraso = 0,
                Ativo = 1
            };
        }

        private Locacao ObterLocacaoEmAtraso()
        {
            return new Locacao()
            {
                IdLocacao = 1,
                IdFilme = 1,
                IdCliente = 1,
                DataLocacao = DateTime.Now.AddDays(-8),
                DataDevolucao = DateTime.Now.AddDays(-1),
                EmAtraso = 0,
                Ativo = 1
            };
        }

        private List<Locacao> ObterLocacoes()
        {
            return new List<Locacao>()
            {
                new Locacao()
                {
                    IdLocacao = 1,
                    IdFilme = 1,
                    IdCliente = 1,
                    DataLocacao = DateTime.Now,
                    DataDevolucao = DateTime.Now.AddDays(7),
                    EmAtraso = 0,
                    Ativo = 1
                },
                new Locacao()
                {
                    IdLocacao = 2,
                    IdFilme = 2,
                    IdCliente = 2,
                    DataLocacao = DateTime.Now,
                    DataDevolucao = DateTime.Now.AddDays(7),
                    EmAtraso = 0,
                    Ativo = 1
                },
            };
        }

        #endregion MÉTODOS AUXILIARES
    }
}
