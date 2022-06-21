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
    public class IndexModel : PageModel
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;



        public IndexModel(IAuthorRepository authorRepository, IMapper mapper) { 
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public List<AuthorDto> Author { get;set; } 

        public async Task OnGetAsync()
        {
            var authors = await authorRepository.GetAuthors();
            Author = mapper.Map<List<AuthorDto>>(authors);
        }
    }
}
