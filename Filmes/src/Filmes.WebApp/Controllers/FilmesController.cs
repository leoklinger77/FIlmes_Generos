using AutoMapper;
using Filmes.Servico.Interfaces;
using Filmes.WebApp.Configuration;
using Filmes.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Filmes.WebApp.Controllers
{
    public class FilmesController : MainController
    {
        private readonly IFilmesServico _filmesServico;

        public FilmesController(IMapper mapper, IFilmesServico filmesServico, INotificacaoServico notificacao)
                                : base(mapper, notificacao)
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
            if (!ModelState.IsValid) return View(await MappingListGeneros(viewModel));

            string path = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageUpload?.FileName);

            if (UploadFile(viewModel.ImageUpload, path).Result)
            {
                viewModel.ImagePath = path;
            }

            await _filmesServico.Insert(_mapper.Map<Domain.Models.Filmes>(viewModel));

            //Validar se a operação foi valida
            if (!ValidOperation())
            {
                return View(await MappingListGeneros(viewModel));
            }

            return RedirectToAction(nameof(Index));

        }

        private async Task<FilmesViewModel> MappingListGeneros(FilmesViewModel viewModel)
        {
            viewModel.Generos = _mapper.Map<IEnumerable<GeneroViewModel>>(await _filmesServico.ListGeneros());
            return viewModel;
        }

        private async Task<bool> UploadFile(IFormFile imageUpload, string imgPath)
        {
            if (imageUpload == null || imageUpload?.Length > 0)
            {
                return false;
            }


            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", imgPath);

            if (System.IO.File.Exists(path))
            {
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageUpload.CopyToAsync(stream);
            }
            return true;
        }
    }
}
