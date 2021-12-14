using Filmes.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Filmes.WebApp.Extensions.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificacaoServico _notificacaoServico;

        public SummaryViewComponent(INotificacaoServico notificacaoServico)
        {
            _notificacaoServico = notificacaoServico;
        }

        public IViewComponentResult Invoke()
        {
            var notificacoes = _notificacaoServico.AllErros().Select(x => x.Error).ToList();

            notificacoes.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x + " <br />"));

            return View(notificacoes);
        }
    }
}
