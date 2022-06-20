using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;
using AutoMapper;
using UniversityLibrary.Dto;

namespace UniversityLibrary.Pages.GenrePage
{
    public class CreateModel : PageModel
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public CreateModel(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public GenreDto Genre { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Genre == null)
            {
                return Page();
            }
            var genreMap = mapper.Map<Genre>(Genre);
            await genreRepository.CreateGenre(genreMap);
            return RedirectToPage("./Index");
        }
    }
}
