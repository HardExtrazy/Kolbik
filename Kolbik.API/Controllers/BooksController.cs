using Kolbik.API.Data;
using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kolbik.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BooksController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }       

        // GET: api/Books/5
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Book>>>> GetBooks(string? author)
        {
            // Создать объект результата
            var result = new ResponseData<IEnumerable<Book>>();
            // Фильтрация по категории загрузка данных категории
            var data = await _context.Books
            .Include(d => d.Author)
            .Where(d => String.IsNullOrEmpty(author)
            || d.Author.Nickname.Equals(author))
            .ToListAsync();
            // Если список пустой
            if (data.Count() == 0)
            {
                return Ok(ResponseData<List<Book>>.Error("Нет объектов в выбраннной категории"));
            }
            return Ok(ResponseData<List<Book>>.OK(data));
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }
        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<IActionResult> SaveImage(int id, IFormFile image)
        {
            // Найти объект по Id 
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // Путь к папке wwwroot/Images 
            var imagesPath = Path.Combine(_env.WebRootPath, "Images");
            // получить случайное имя файла 
            var randomName = Path.GetRandomFileName();
            // получить расширение в исходном файле 
            var extension = Path.GetExtension(image.FileName);
            // задать в новом имени расширение как в исходном файле 
            var fileName = Path.ChangeExtension(randomName, extension);
            // полный путь к файлу 
            var filePath = Path.Combine(imagesPath, fileName);
            // создать файл и открыть поток для записи 
            using var stream = System.IO.File.OpenWrite(filePath);
            // скопировать файл в поток 
            await image.CopyToAsync(stream);
            // получить Url хоста 
            var host = "https://" + Request.Host;
            // Url файла изображения 
            var url = $"{host}/Images/{fileName}";
            // Сохранить url файла в объекте 
            book.Image = url;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
