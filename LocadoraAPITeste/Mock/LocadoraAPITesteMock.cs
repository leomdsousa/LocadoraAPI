using LocadoraAPI.Repositories.Interfaces;
using LocadoraAPI.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAPITeste.Mock
{
    internal class LocadoraAPITesteMock
    {
        public Mock<IClienteService> ClienteService { get; set; }
        public Mock<IFilmeService> FilmeService { get; set; }
        public Mock<ILocacaoService> LocacaoService { get; set; }

        public Mock<IClienteRepository> ClienteRepository { get; set; }
        public Mock<IFilmeRepository> FilmeRepository { get; set; }
        public Mock<ILocacaoRepository> LocacaoRepository { get; set; }

        public LocadoraAPITesteMock()
        {
            ClienteService = new Mock<IClienteService>();
            FilmeService = new Mock<IFilmeService>();
            LocacaoService = new Mock<ILocacaoService>();
            ClienteRepository = new Mock<IClienteRepository>();
            FilmeRepository = new Mock<IFilmeRepository>();
            LocacaoRepository = new Mock<ILocacaoRepository>();
        }

    }
}
