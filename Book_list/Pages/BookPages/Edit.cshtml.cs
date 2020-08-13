using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Book_list.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book_list.Pages.BookPages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public BookTable BookEdit { get; set; }

        public async Task OnGet(int id)
        {
            BookEdit = await _db.BookTables.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookForUpdate = await _db.BookTables.FindAsync(BookEdit.Id);
                BookForUpdate.Name = BookEdit.Name;
                BookForUpdate.Author = BookEdit.Author;
                BookForUpdate.ISBN = BookEdit.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("MainIndex");

            }
            return RedirectToPage();
        }

    }
}
