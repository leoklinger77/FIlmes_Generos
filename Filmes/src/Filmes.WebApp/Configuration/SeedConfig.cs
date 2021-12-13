using Bogus;
using Filmes.Data.Context;
using Filmes.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Filmes.WebApp.Configuration
{
    public class SeedConfig
    {
        private readonly FilmeDbContext _context;

        public SeedConfig(FilmeDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Genero.Any())
            {
                return;
            }

            var genero = new Faker<Genero>("pt_BR").CustomInstantiator(x => new Genero(new Faker().Commerce.Categories(1).First(), new Faker().Commerce.ProductName()));


            List<Genero> listGeneros = genero.Generate(15);

            _context.Genero.AddRange(listGeneros);
            _context.SaveChanges();
        }
    }
}
