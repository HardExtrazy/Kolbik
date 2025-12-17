using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;

namespace Kolbik.UI.Services
{
    public class MemoryBookService : IBookService
    {
        private readonly IBookService _bookService;
        List<Book> _books;
        List<Author> _authors;
        public MemoryBookService(IAuthorService authorService)
        {
            _authors = authorService.GetAuthorListAsync().Result.Data;
            SetupData();
        }
        public void SetupData()
        {
            _books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Name = "Стрелок",
                    Description = "Книга про стрелка Рональда",
                    Rating = 9,
                    Image = "images/Стрелок.jpg",
                    Author = _authors.FirstOrDefault(a => a.Id == 1),
                    AuthorId = _authors.Find(c => c.Nickname.Equals("Стивен Кинг"))!.Id
                },
                new Book
                {
                    Id = 2,
                    Name = "Евгений Онегин",
                    Description = "Книга о лишнем человеке",
                    Rating = 7,
                    Image = "images/Онегин.jpg",
                    Author = _authors.FirstOrDefault(a => a.Id == 2),
                    AuthorId = _authors.Find(c => c.Nickname.Equals("Александер Пушкин"))!.Id
                },
                 new Book
                {
                    Id = 3,
                    Name = "Остров  в океане",
                    Description = "Книга об одиночестве",
                    Rating = 2,
                    Image = "images/Остров.jpg",
                    Author = _authors.FirstOrDefault(a => a.Id == 3),
                    AuthorId = _authors.Find(c => c.Nickname.Equals("Пророк"))!.Id
                },
                  new Book
                {
                    Id = 4,
                    Name = "Что такое денди?",
                    Description = "Руководство о приставке",
                    Rating = 8,
                    Image = "images/Денди.jpg",
                    Author = _authors.FirstOrDefault(a => a.Id == 4),
                    AuthorId = _authors.Find(c => c.Nickname.Equals("Санбой"))!.Id
                },
                   new Book
                {
                    Id = 5,
                    Name = "Русские медведи",
                    Description = "Приключение друзей",
                    Rating = 10,
                    Image = "images/Приключения.jpg",
                    Author = _authors.FirstOrDefault(a => a.Id == 5),
                    AuthorId = _authors.Find(c => c.Nickname.Equals("Шалфей"))!.Id
                },
                    new Book
                {
                    Id = 6,
                    Name = "Грязный Вилли",
                    Description = "Детектив Дикого Запада",
                    Rating = 4,
                    Image = "images/Вилли.jpg",
                    Author = _authors.FirstOrDefault(a => a.Id == 6),
                    AuthorId = _authors.Find(c => c.Nickname.Equals("Кристи"))!.Id
                }
            };
        }
        public Task<ResponseData<List<Book>>> GetBookListAsync(string? author)
        {
            var temp = _books.Where(d => String.IsNullOrEmpty(author) || d.Author.Nickname.Equals(author)).ToList();
            var result = ResponseData<List<Book>>.OK(temp);
            return Task.FromResult(result);
        }
        public Task<ResponseData<Book>> CreateBookAsync(Book book, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
        public Task DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseData<Book>> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(int id, Book book, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }
}
