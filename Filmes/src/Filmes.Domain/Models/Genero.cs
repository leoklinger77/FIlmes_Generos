using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filmes.Domain.Models
{
    public class Genero : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        private List<Filmes> _filmes = new List<Filmes>();
        public IReadOnlyCollection<Filmes> Filmes => _filmes;

        protected Genero() { }

        public Genero(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public void AddFiles(Filmes filmes)
        {
            _filmes.Add(filmes);
        }

        public void RemoveFiles(Filmes filmes)
        {
            //TODO Verificar se existe na lista
            _filmes.Remove(filmes);
        }

        public void UpdateFiles(Filmes filmes)
        {
            //TODO Verificar se existe na lista
            var filmeExiste = _filmes.Where(x => x.Id == filmes.Id).FirstOrDefault();
            
            if (filmeExiste == null) throw new Exception("Filme não existe na lista");
            _filmes.Remove(filmeExiste);
            _filmes.Add(filmes);
        }
    }
}
