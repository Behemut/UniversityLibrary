using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;

namespace UniversityLibrary.Pages.BookPage
{
    public class DeleteModel : PageModel
    {
        private readonly IBookRepository bookRepository;

        public DeleteModel(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [BindProperty]
      public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Book = await bookRepository.GetBookByIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await bookRepository.DeleteBook(id);

            return RedirectToPage("./Index");
        }
    }
}
