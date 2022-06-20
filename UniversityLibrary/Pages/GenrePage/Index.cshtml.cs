using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;
using AutoMapper;
using UniversityLibrary.Dto;

namespace UniversityLibrary.Pages.GenrePage
{
    public class IndexModel : PageModel
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public IndexModel(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public List<GenreDto> Genre { get;set; } 

        public async Task OnGetAsync()
        {
            var genres = await genreRepository.GetGenres();
            Genre = mapper.Map<List<GenreDto>>(genres);
        }
    }
}
