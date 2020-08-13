using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_list.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_list.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly AppDbContext _db;
        public BookController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.BookTables.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var BookFromDb = await _db.BookTables.FirstOrDefaultAsync(u => u.Id == id);
            if (BookFromDb == null)
            {
                return Json(new { success = false, message = "No Book Found" });
            }
            _db.BookTables.Remove(BookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Book Delete Successfully" });


        }
    }
}
