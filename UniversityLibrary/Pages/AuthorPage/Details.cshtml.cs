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

namespace UniversityLibrary.Pages.AuthorPage
{
    public class DetailsModel : PageModel
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public DetailsModel(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public AuthorDto Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = mapper.Map<AuthorDto>(await authorRepository.GetAuthor(id));
            Author = author;
            return Page();
        }
    }
}
