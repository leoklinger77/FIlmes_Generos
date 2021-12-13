using AutoMapper;
using Filmes.WebApp.Models;

namespace Filmes.WebApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<FilmesViewModel, Domain.Models.Filmes>().ReverseMap();
            CreateMap<GeneroViewModel, Domain.Models.Genero>().ReverseMap();
        }
    }
}
