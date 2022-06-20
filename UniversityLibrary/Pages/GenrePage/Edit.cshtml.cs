using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;
using AutoMapper;
using UniversityLibrary.Dto;


namespace UniversityLibrary.Pages.GenrePage
{
    public class EditModel : PageModel
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;


        public EditModel(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var genre = mapper.Map<Genre>(Genre);
            await genreRepository.UpdateGenre(genre);
            return RedirectToPage("./Index");
        }


    }
}
