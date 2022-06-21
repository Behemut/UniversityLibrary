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
using UniversityLibrary.Data;

namespace UniversityLibrary.Pages.BookPage
{
    public class EditModel : PageModel
    {
        private readonly IBookRepository  bookRepository;
        private readonly DataContext context;
        
        public EditModel(IBookRepository bookRepository, DataContext context)
        {
            this.bookRepository = bookRepository;
            this.context = context;
        }

        [BindProperty]
        public Book Book { get; set; }


        [BindProperty]
        public int[] SelectedAuthors { get; set; }
        public SelectList OptionsAuthors { get; set; }
        [BindProperty]
        public int[] SelectedGenres { get; set; }
        public SelectList OptionsGenres { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Book = await bookRepository.GetBookByIdAsync(id);
            
            OptionsAuthors = new SelectList(context.Authors, nameof(Author.Id), nameof(Author.Name));
            OptionsGenres = new SelectList(context.Genres, nameof(Genre.Id), nameof(Genre.Name));

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        { 
            await bookRepository.UpdateBook(Book,  SelectedAuthors, SelectedGenres);
            return RedirectToPage("./Index");
        }


        
    }
}
