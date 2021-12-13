using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmes.Servico.Interfaces
{
    public interface IFilmesServico
    {
        Task<IEnumerable<Domain.Models.Filmes>> FilmesAll();
        Task<Domain.Models.Filmes> FindById(Guid Id);
        Task Insert(Domain.Models.Filmes filmes);
        Task Update(Domain.Models.Filmes filmes);
        Task Remove(Domain.Models.Filmes filmes);
        Task<IEnumerable<Domain.Models.Genero>> ListGeneros();
    }
}
