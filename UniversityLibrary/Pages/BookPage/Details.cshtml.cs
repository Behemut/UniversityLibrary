using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;
using UniversityLibrary.Dto;

namespace UniversityLibrary.Pages.BookPage
{
    public class DetailsModel : PageModel
    {
        private readonly IBookRepository bookRepository;

        public DetailsModel(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book Book { get; set; }
        public List<Author> Author { get; set; }
        public List<Genre> Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Author = await bookRepository.GetAuthorsByBook(id);

            Genre = await bookRepository.GetGenresByBook(id);


            Book = await bookRepository.GetBookByIdAsync(id);
            return Page();
        }
    }
}
