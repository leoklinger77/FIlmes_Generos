using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmes.WebApp.Models
{
    public class FilmesViewModel
    {
        public Guid Id { get; set; }
        public Guid GeneroId { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatorio")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter no minimo {2} e no máximo {1} caracteres.")]
        [Display(Name ="Título")]
        public string Titulo { get; set; }

        [Required]
        public string Diretor { get; set; }

        public string ImagePath { get; set; }
        public IFormFile ImageUpload { get; set; }

        public GeneroViewModel Genero { get; set; }




        public IEnumerable<GeneroViewModel> Generos { get; set; }
    }
}

