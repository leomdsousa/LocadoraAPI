using LocadoraAPI.Models;

namespace LocadoraAPI.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ObterClientes(); 
        Cliente ObterCliente(int idCliente);
        Cliente CadastrarCliente(Cliente cliente);
    }
}
