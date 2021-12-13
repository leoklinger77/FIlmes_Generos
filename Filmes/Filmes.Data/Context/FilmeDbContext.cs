using Filmes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Data.Context
{
    public class FilmeDbContext : DbContext
    {
        public FilmeDbContext(DbContextOptions<FilmeDbContext> options) : base(options) { }

        public DbSet<Domain.Models.Filmes> Filmes { get; set; }
        public DbSet<Genero> Genero { get; set; }
    }
}
