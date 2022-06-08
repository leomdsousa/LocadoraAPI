using LocadoraAPI.Context;
using LocadoraAPI.Models;
using LocadoraAPI.Repositories.Interfaces;

namespace LocadoraAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private LocadoraDBContext _context;

        public FilmeRepository(LocadoraDBContext context)
        {
            _context = context;
        }

        public Filme CadastrarFilme(Filme cliente)
        {
            throw new NotImplementedException();
        }

        public Filme ObterFilme(int idFilme)
        {
            throw new NotImplementedException();
        }

        public List<Filme> ObterFilmes()
        {
            throw new NotImplementedException();
        }
    }
}
