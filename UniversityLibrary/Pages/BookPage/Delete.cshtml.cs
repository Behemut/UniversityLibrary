using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;
using AutoMapper;
using UniversityLibrary.Dto;

namespace UniversityLibrary.Pages.BookPage
{
    public class DeleteModel : PageModel
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
        public DeleteModel(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        [BindProperty]
      public BookDto Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var book = mapper.Map<BookDto>(await bookRepository.GetBookByIdAsync(id));
            Book = book;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await bookRepository.DeleteBook(id);

            return RedirectToPage("./Index");
        }
    }
}
