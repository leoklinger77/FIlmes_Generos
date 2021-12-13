using Filmes.Data.Context;
using Filmes.Servico.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Filmes.Data.Repositorio
{
    public class FilmesRepositorio : IFilmesRepositorio
    {
        private readonly FilmeDbContext _context;

        public FilmesRepositorio(FilmeDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Filmes> Find(Expression<Func<Domain.Models.Filmes, bool>> predicate)
        {
            return await _context.Filmes.Include(x => x.Genero).Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Insert(Domain.Models.Filmes filmes)
        {
            await _context.AddAsync(filmes);            
        }

        public async Task Remove(Domain.Models.Filmes filmes)
        {
            _context.Remove(filmes);
            await Task.CompletedTask;
        }       

        public async Task<IEnumerable<Domain.Models.Filmes>> ToList()
        {
            return await _context.Filmes.Include(x => x.Genero).ToListAsync();
        }

        public async Task Update(Domain.Models.Filmes filmes)
        {
            _context.Update(filmes);
            await Task.CompletedTask;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
