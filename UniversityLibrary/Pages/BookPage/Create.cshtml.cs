﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityLibrary.Models;
using UniversityLibrary.Interfaces;
using UniversityLibrary.Data;

using AutoMapper;
using UniversityLibrary.Dto;

namespace UniversityLibrary.Pages.BookPage
{
    public class CreateModel : PageModel
    {
        private readonly DataContext context;
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;
        public CreateModel(IBookRepository bookRepository,IAuthorRepository authorRepository,IMapper mapper, DataContext context)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.mapper = mapper;
            this.context = context;
        }
        [BindProperty]
        public int authorId { get; set; }
        public List<SelectListItem> Authors { get; set; }
        public void OnGet()
        {
            Authors = context.Authors.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
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
            var number = Request.Form["authorId"];
            authorId = Convert.ToInt32(number);
            var bookMap = mapper.Map<Book>(Book);
            await bookRepository.CreateBook(bookMap, authorId);
            return RedirectToPage("./Index");
        }

        
    }
}
