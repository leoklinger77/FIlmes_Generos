using Filmes.Domain.Models;
using System.Collections.Generic;

namespace Filmes.Servico.Interfaces
{
    public interface INotificacaoServico
    {
        void AddError(string error);

        bool HasError();

        IEnumerable<Notificacao> AllErros();
    }
}
