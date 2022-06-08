using LocadoraAPI.DTOs;
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
            throw new NotImplementedException();
        }

        public ClienteDTO ObterCliente(int idCliente)
        {
            var dados = _repository.ObterCliente(idCliente);

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
