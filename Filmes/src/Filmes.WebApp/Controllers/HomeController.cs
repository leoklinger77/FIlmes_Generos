using AutoMapper;
using Filmes.Servico.Interfaces;
using Filmes.WebApp.Configuration;
using Filmes.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Filmes.WebApp.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(IMapper mapper, ILogger<HomeController> logger, INotificacaoServico notificacao)
                                : base(mapper, notificacao)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
