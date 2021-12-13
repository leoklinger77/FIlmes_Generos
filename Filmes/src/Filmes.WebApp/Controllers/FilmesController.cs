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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var result = new FilmesViewModel();

            return View(await MappingListGeneros(result));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(FilmesViewModel viewModel)
        {
            if(!ModelState.IsValid) return View(await MappingListGeneros(viewModel));


            await _filmesServico.Insert(_mapper.Map<Domain.Models.Filmes>(viewModel));

            //Validar se a operação foi valida

            return RedirectToAction(nameof(Index));

        }

        private async Task<FilmesViewModel> MappingListGeneros(FilmesViewModel viewModel)
        {
            viewModel.Generos = _mapper.Map<IEnumerable<GeneroViewModel>>(await _filmesServico.ListGeneros());
            return viewModel;
        }
    }
}
