using AutoMapper;
using Filmes.Servico.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.WebApp.Configuration
{
    [Authorize]    
    public abstract class MainController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly INotificacaoServico _notificacao;

        protected MainController(IMapper mapper, INotificacaoServico notificacao)
        {
            _mapper = mapper;
            _notificacao = notificacao;
        }

        protected bool ValidOperation()
        {
            if (_notificacao.HasError())
            {                
                return false;
            }
            return true;
        }
    }
}
