using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;
        private string? BookField;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedBook { get; set; }


        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            // Use LINQ to get distinct books, dates and titles from the Scriptures
            IQueryable<string> bookQuery = from s in _context.Scripture
                                           orderby s.Book
                                           select s.Book;
            // </snippet_search_linqQuery>
            var scriptures = from s in _context.Scripture
                             select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SelectedBook))
            {
                scriptures = scriptures.Where(x => x.Book == SelectedBook);
            }

            // using System;
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            switch (sortOrder)
            {
                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    scriptures = scriptures.OrderBy(s => s.AddedDate);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.AddedDate);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
            }

            Book = new SelectList(await bookQuery.Distinct().ToListAsync());

            Scripture = await scriptures.ToListAsync();
            Scripture = await scriptures.AsNoTracking().ToListAsync();
        }
        /*public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["BookSortParm"] = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "Book";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var scriptures = from s in _context.Scripture
                                    select s;
            switch (sortOrder)
            {
                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    scriptures = scriptures.OrderBy(s => s.AddedDate);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.AddedDate);
                    break;
            default:
                scriptures = scriptures.OrderBy(s => s.Book);
            break;
            }
            Scripture = await scriptures.AsNoTracking().ToListAsync();
            return Page();
        }*/
    }
}
