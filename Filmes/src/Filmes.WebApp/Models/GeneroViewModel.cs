using System;
using System.Collections.Generic;

namespace Filmes.WebApp.Models
{
    public class GeneroViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }

        public IEnumerable<FilmesViewModel> Filmes = new List<FilmesViewModel>();
        
    }
}

