using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.WebApp.Configuration
{
    [Authorize]    
    public abstract class MainController : Controller
    {
        protected readonly IMapper _mapper;

        protected MainController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
