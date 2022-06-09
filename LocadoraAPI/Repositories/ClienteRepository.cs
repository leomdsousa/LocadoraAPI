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
            if (cliente is null)
                throw new NullReferenceException("Cliente nulo.");

            var entity = _context.Set<Cliente>().Add(cliente);
            var count = _context.SaveChanges();

            return count > 0 ? entity.Entity : null;
        }

        public Cliente ObterCliente(int idCliente)
        {
            return _context.Set<Cliente>().FirstOrDefault(x => x.IdCliente == idCliente);
        }

        public List<Cliente> ObterClientes()
        {
            return _context.Set<Cliente>().ToList();
        }

        public bool ExisteCliente(string nomeCliente)
        {
            return _context.Set<Cliente>().Any(x => x.NomeCliente == nomeCliente && x.Ativo == 1);
        }
    }
}
