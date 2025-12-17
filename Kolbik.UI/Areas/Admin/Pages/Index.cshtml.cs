using Kolbik.Domain.Entities;
using Kolbik.UI;
using Kolbik.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolbik.UI.Areas.Admin.Pages
{
    [Authorize(Policy ="admin")]
    public class IndexModel(IBookService bookService) : PageModel
    {
        //private readonly Kolbik.UI.TempContext _context;

        //public IndexModel(Kolbik.UI.TempContext context)
        //{
        //    _context = context;
        //}

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = (await bookService.GetBookListAsync(null)).Data;
        }
    }
}
