using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;

namespace Kolbik.UI.Services
{
    public interface IBookService
    {
        public Task<ResponseData<List<Book>>> GetBookListAsync(string? author);
        public Task<ResponseData<Book>> GetBookByIdAsync(int  id);
        public Task UpdateBookAsync(int  id, Book book, IFormFile? formFile);
        public Task DeleteBookAsync(int id);
        public Task<ResponseData<Book>> CreateBookAsync(Book book, IFormFile? formFile);
    }
}
