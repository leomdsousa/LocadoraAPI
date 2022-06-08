using LocadoraAPI.DTOs;
using LocadoraAPI.Repositories.Interfaces;
using LocadoraAPI.Services.Interfaces;

namespace LocadoraAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private IFilmeRepository _repository;

        public FilmeService(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public FilmeDTO CadastrarFilme(FilmeDTO dto)
        {
            throw new NotImplementedException();
        }

        public FilmeDTO ObterFilme(int idFilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDTO> ObterFilmes()
        {
            throw new NotImplementedException();
        }
    }
}
