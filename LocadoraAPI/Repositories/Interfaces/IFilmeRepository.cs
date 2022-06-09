using LocadoraAPI.Models;

namespace LocadoraAPI.Repositories.Interfaces
{
    public interface IFilmeRepository
    {
        List<Filme> ObterFilmes();
        Filme ObterFilme(int idFilme);
        Filme CadastrarFilme(Filme filme);
    }
}
