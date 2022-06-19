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

namespace UniversityLibrary.Pages.BookPage
{
    public class IndexModel : PageModel
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
        public IndexModel(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

 
        public List<BookDto> Book { get; set; }
        public async Task OnGetAsync()
        {
            var books = await bookRepository.GetBooks();
            Book = mapper.Map<List<BookDto>>(books);
            
        }
    }
}
