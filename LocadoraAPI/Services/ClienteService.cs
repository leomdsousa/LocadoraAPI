using LocadoraAPI.DTOs;
using LocadoraAPI.Models;
using LocadoraAPI.Repositories.Interfaces;
using LocadoraAPI.Services.Interfaces;

namespace LocadoraAPI.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public ClienteDTO CadastrarCliente(ClienteDTO dto)
        {
            var existeCliente = _repository.ExisteCliente(dto.NomeCliente);

            if (existeCliente)
                throw new InvalidOperationException("Já existe usuário cadastrado com o mesmo nome.");

            var cliente = new Cliente()
            {
                IdCliente = 0,
                NomeCliente = dto.NomeCliente,
                Ativo = dto.Ativo ? 1 : 0,
            };

            var retorno = _repository.CadastrarCliente(cliente);

            if (retorno is null) return null;

            return new ClienteDTO()
            {
                IdCliente = retorno.IdCliente,
                NomeCliente = retorno.NomeCliente,
                Ativo = retorno.Ativo == 1 ? true : false
            };
        }

        public ClienteDTO ObterCliente(int idCliente)
        {
            var dados = _repository.ObterCliente(idCliente);

            if (dados is null) return null;

            return new ClienteDTO()
            {
                IdCliente = dados.IdCliente,
                NomeCliente = dados.NomeCliente,
                Ativo = dados.Ativo == 1 ? true : false
            };
        }

        public List<ClienteDTO> ObterClientes()
        {
            var dados = _repository.ObterClientes();

            if (dados?.Count == 0) return null;

            return dados.Select(x => new ClienteDTO()
            {
                IdCliente = x.IdCliente,
                NomeCliente = x.NomeCliente,
                Ativo = x.Ativo == 1 ? true : false
            })
            .ToList();
        }
    }
}
