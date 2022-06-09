using LocadoraAPI.DTOs;
using LocadoraAPI.Models;
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
            var filme = new Filme()
            {
                IdFilme = 0,
                NomeFilme = dto.NomeFilme,
                Ativo = dto.Ativo ? 1 : 0,
            };

            var retorno = _repository.CadastrarFilme(filme);

            if (retorno is null) return null;

            return new FilmeDTO()
            {
                IdFilme = retorno.IdFilme,
                NomeFilme = retorno.NomeFilme,
                Ativo = retorno.Ativo == 1 ? true : false
            };
        }

        public FilmeDTO ObterFilme(int idFilme)
        {
            var dados = _repository.ObterFilme(idFilme);

            if (dados is null) return null;

            return new FilmeDTO()
            {
                IdFilme = dados.IdFilme,
                NomeFilme = dados.NomeFilme,
                Ativo = dados.Ativo == 1 ? true : false
            };
        }

        public List<FilmeDTO> ObterFilmes()
        {
            var dados = _repository.ObterFilmes();

            if(dados?.Count == 0) return null;

            return dados.Select(x => new FilmeDTO()
            {
                IdFilme = x.IdFilme,
                NomeFilme = x.NomeFilme,
                Ativo = x.Ativo == 1 ? true : false
            })
            .ToList();
        }
    }
}
