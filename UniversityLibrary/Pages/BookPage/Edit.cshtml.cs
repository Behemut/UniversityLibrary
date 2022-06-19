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

namespace UniversityLibrary.Pages.BookPage
{
    public class EditModel : PageModel
    {
        private readonly IBookRepository  bookRepository;

        public EditModel(IBookRepository bookRepository)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (ModelState.IsValid)
            {
                await bookRepository.UpdateBook(Book);
                return RedirectToPage("./Index");
            }
            return Page();
            */
            await bookRepository.UpdateBook(Book);
            return RedirectToPage("./Index");


        }


        
    }
}
