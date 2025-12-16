using Kolbik.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolbik.UI.Controllers
{
    public class ProductController(IAuthorService authorService, IBookService bookService) : Controller
    {
        public async Task<IActionResult> Index(string? author)
        {
            ViewData["Authors"] = authorService.GetAuthorListAsync().Result.Data;
            ViewData["CurrentAuthor"] = String.IsNullOrEmpty(author)? "Все авторы" : author;
            var result = await bookService.GetBookListAsync(author);
            if (!result.Success)
                return BadRequest(result.ErrorMessage);
            return View(result.Data);
        }
    }
}
