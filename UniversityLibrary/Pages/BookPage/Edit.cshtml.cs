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
using AutoMapper;
using UniversityLibrary.Dto;

namespace UniversityLibrary.Pages.BookPage
{
    public class EditModel : PageModel
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
        private readonly DataContext context;
        
        public EditModel(IBookRepository bookRepository, DataContext context, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.context = context;
            this.mapper = mapper;
        }
        [BindProperty]
        public BookDto Book { get; set; }

        [BindProperty]
        public int[] SelectedAuthors { get; set; }
        public SelectList OptionsAuthors { get; set; }
        [BindProperty]
        public int[] SelectedGenres { get; set; }
        public SelectList OptionsGenres { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = mapper.Map<BookDto>(await bookRepository.GetBookByIdAsync(id));
            Book = book;
    
            OptionsAuthors = new SelectList(context.Authors, nameof(Author.Id), nameof(Author.Name));
            OptionsGenres = new SelectList(context.Genres, nameof(Genre.Id), nameof(Genre.Name));

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var book = mapper.Map<Book>(Book);
            await bookRepository.UpdateBook(book, SelectedAuthors, SelectedGenres);
            return RedirectToPage("./Index");
        }   
    }
}
