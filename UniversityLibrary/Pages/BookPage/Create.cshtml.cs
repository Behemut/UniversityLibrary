﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;

namespace UniversityLibrary.Pages.BookPage
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepository bookRepository;

        public CreateModel(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } 
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*
          if (ModelState.IsValid )
            {
                return Page();
            }
                */

            await bookRepository.CreateBook(Book);
            return RedirectToPage("./Index");
        }
    }
}
