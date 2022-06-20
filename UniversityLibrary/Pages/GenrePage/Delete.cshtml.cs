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
    public class DeleteModel : PageModel
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public DeleteModel(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }
        [BindProperty]
      public GenreDto Genre { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            await genreRepository.DeleteGenre(id);
            return RedirectToPage("./Index");
        }



    }
}
