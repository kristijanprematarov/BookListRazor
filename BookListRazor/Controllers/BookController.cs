using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/{controller}")]
    public class BookController : Controller
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data = await _context.Books.ToListAsync()});
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookFromDb is null)
            {
                return Json(new {success=false, message="Error while deleting.."});
            }

            _context.Remove(bookFromDb);
            await _context.SaveChangesAsync();

            return Json(new {success = true, message = "Delete was successful"});
        }


    }
}
