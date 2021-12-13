using Filmes.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmes.Servico.Servicos
{
    public class FilmesServico : IFilmesServico
    {
        private readonly IFilmesRepositorio _filmesRepositorio;

        public FilmesServico(IFilmesRepositorio filmesRepositorio)
        {
            _filmesRepositorio = filmesRepositorio;
        }

        public async Task<Domain.Models.Filmes> FindById(Guid Id)
        {
            var result = await _filmesRepositorio.Find(x => x.Id == Id);
            
            //Validar se é nulo, caso seja retornar erro

            return result;
        }

        public async Task<IEnumerable<Domain.Models.Filmes>> FilmesAll()
        {
            return await _filmesRepositorio.ToList();
        }

        public async Task Insert(Domain.Models.Filmes filmes)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Domain.Models.Filmes filmes)
        {
            throw new NotImplementedException();
        }        

        public async Task Update(Domain.Models.Filmes filmes)
        {
            throw new NotImplementedException();
        }
    }
}
