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

namespace UniversityLibrary.Pages.BookPage
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public CreateModel(IBookRepository bookRepository,IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookDto Book { get; set; } 
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Book == null)
            {
                return Page();
            }
            var bookMap = mapper.Map<Book>(Book);
            await bookRepository.CreateBook(bookMap);
            return RedirectToPage("./Index");
        }

        
    }
}
