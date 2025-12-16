using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;

namespace Kolbik.UI.Services
{
    public interface IBookService
    {
        public Task<ResponseData<List<Book>>> GetBookListAsync(string? author);
        public Task<ResponseData<Book>> GetBookByIdAsync(uint  id);
        public Task UpdateBookAsync(uint  id, Book book, IFormFile? formFile);
        public Task DeleteBookAsync(uint id);
        public Task<ResponseData<Book>> CreateBookAsync(Book book, IFormFile? formFile);
    }
}
