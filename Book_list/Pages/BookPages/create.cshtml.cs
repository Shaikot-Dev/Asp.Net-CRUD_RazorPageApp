using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_list.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_list.Pages.BookPages
{
    public class createModel : PageModel
    {
        private readonly AppDbContext _db;
        public createModel(AppDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public BookTable BookCreatePage { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.BookTables.AddAsync(BookCreatePage);
                await _db.SaveChangesAsync();
                return RedirectToPage("MainIndex");
            }
            else
            {
                return Page();

            }

        }
    }
}
