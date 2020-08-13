using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_list.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book_list.Pages.BookPages
{
    public class MainIndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public MainIndexModel(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<BookTable> BookInMainIndex { get; set; }
        public async Task OnGet()
        {
            BookInMainIndex = await _db.BookTables.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var BookDelete = await _db.BookTables.FindAsync(id);
            if (BookDelete == null)
            {
                return NotFound();
            }
            _db.BookTables.Remove(BookDelete);
            await _db.SaveChangesAsync();
            return RedirectToPage("MainIndex");


        }


    }
}
