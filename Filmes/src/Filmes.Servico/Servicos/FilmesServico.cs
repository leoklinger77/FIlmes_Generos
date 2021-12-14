using Filmes.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmes.Servico.Servicos
{
    public class FilmesServico : IFilmesServico
    {
        private readonly IFilmesRepositorio _filmesRepositorio;
        private readonly INotificacaoServico _notificacaoServico;

        public FilmesServico(IFilmesRepositorio filmesRepositorio, INotificacaoServico notificacaoServico)
        {
            _filmesRepositorio = filmesRepositorio;
            _notificacaoServico = notificacaoServico;
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
            if(_filmesRepositorio.Find(x => x.Titulo == filmes.Titulo).Result != null)
            {
                _notificacaoServico.AddError("O titulo cadastrado já existe.");
                return;
            }

            await _filmesRepositorio.Insert(filmes);
            await _filmesRepositorio.SaveChanges();            
        }

        public async Task Remove(Domain.Models.Filmes filmes)
        {
            throw new NotImplementedException();
        }        

        public async Task Update(Domain.Models.Filmes filmes)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Models.Genero>> ListGeneros()
        {
            return await _filmesRepositorio.ListGeneros();
        }
    }
}
