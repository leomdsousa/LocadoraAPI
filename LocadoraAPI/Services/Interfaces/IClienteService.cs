using LocadoraAPI.DTOs;
using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAPI.Services.Interfaces
{
    public interface IClienteService
    {

        List<ClienteDTO> ObterClientes();
        ClienteDTO ObterCliente(int idCliente);
        ClienteDTO CadastrarCliente(ClienteDTO dto);

    }
}
