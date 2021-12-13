using System;

namespace Filmes.Domain.Models
{
    public class Filmes : Entity
    {
        public Guid GeneroId { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }
        public string ImagePath { get; private set; }
        public Genero Genero { get; private set; }
        protected Filmes() { }

        public Filmes(Guid generoId, string titulo, string diretor)
        {
            GeneroId = generoId;
            Titulo = titulo;
            Diretor = diretor;  
        }

        public void SetImagePath(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
