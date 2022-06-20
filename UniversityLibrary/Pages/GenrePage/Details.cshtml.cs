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
    public class DetailsModel : PageModel
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public DetailsModel(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public GenreDto Genre { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var genre = mapper.Map<GenreDto>(await genreRepository.GetGenre(id));
            Genre = genre;

            return Page();
        }
    }
}
