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

namespace UniversityLibrary.Pages.AuthorPage
{
    public class CreateModel : PageModel
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public CreateModel(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AuthorDto Author { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Author == null)
            {
                return Page();
            }
            var authorMap = mapper.Map<Author>(Author);
            await authorRepository.CreateAuthor(authorMap);
            return RedirectToPage("./Index");
        }
    }
}
