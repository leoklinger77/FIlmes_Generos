using System;

namespace Filmes.WebApp.Models
{
    public class FilmesViewModel
    {
        public Guid Id { get; set; }
        public Guid GeneroId { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string ImagePath { get; set; }
        public GeneroViewModel Genero { get; set; }
    }
}

