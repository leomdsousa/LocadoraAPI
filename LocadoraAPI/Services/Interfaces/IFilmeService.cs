using LocadoraAPI.DTOs;

namespace LocadoraAPI.Services.Interfaces
{
    public interface IFilmeService
    {
        List<FilmeDTO> ObterFilmes();
        FilmeDTO ObterFilme(int idFilme);
        FilmeDTO CadastrarFilme(FilmeDTO dto);
    }
}
