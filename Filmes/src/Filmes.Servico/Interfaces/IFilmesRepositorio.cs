using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Filmes.Servico.Interfaces
{
    public interface IFilmesRepositorio
    {
        Task<IEnumerable<Domain.Models.Filmes>> ToList();
        Task<Domain.Models.Filmes> Find(Expression<Func<Domain.Models.Filmes, bool>> predicate);
        Task Insert(Domain.Models.Filmes filmes);
        Task Update(Domain.Models.Filmes filmes);
        Task Remove(Domain.Models.Filmes filmes);


        Task<int> SaveChanges();
    }
}
