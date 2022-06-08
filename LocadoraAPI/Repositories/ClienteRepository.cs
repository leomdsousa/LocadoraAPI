using LocadoraAPI.Context;
using LocadoraAPI.Models;
using LocadoraAPI.Repositories.Interfaces;

namespace LocadoraAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private LocadoraDBContext _context;

        public ClienteRepository(LocadoraDBContext context)
        {
            _context = context;
        }

        public Cliente CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterCliente(int idCliente)
        {
            return _context.Set<Cliente>().FirstOrDefault(x => x.IdCliente == idCliente);
        }

        public List<Cliente> ObterClientes()
        {
            return _context.Set<Cliente>().ToList();
        }
    }
}
