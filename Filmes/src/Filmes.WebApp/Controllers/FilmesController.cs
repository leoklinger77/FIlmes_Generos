using AutoMapper;
using Filmes.Servico.Interfaces;
using Filmes.WebApp.Configuration;
using Filmes.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmes.WebApp.Controllers
{
    public class FilmesController : MainController
    {
        private readonly IFilmesServico _filmesServico;

        public FilmesController(IMapper mapper, IFilmesServico filmesServico) : base(mapper)
        {
            _filmesServico = filmesServico;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FilmesViewModel>>(await _filmesServico.FilmesAll()));
        }
    }
}
