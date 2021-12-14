using Filmes.Domain.Models;
using Filmes.Servico.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Filmes.Servico.Servicos
{
    public class NotificacaoServico : INotificacaoServico
    {
        private List<Notificacao> listaErros = new List<Notificacao>();

        public NotificacaoServico() { }

        public void AddError(string error)
        {
            listaErros.Add(new Notificacao(error));
        }

        public IEnumerable<Notificacao> AllErros()
        {
            return listaErros;
        }

        public bool HasError()
        {
            return listaErros.Any();
        }
    }
}
