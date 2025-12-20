using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;
using static System.Net.WebRequestMethods;

namespace Kolbik.Blazor.Services
{
    public class ApiBookService(HttpClient Http): IBookService<Book>
    {
        List<Book> _books = new();
        int _currentPage = 1;
        int _totalPages = 1;
        public IEnumerable<Book> Books => _books;
        public int CurrentPage => _currentPage;
        public int TotalPages => _totalPages;
        public event Action ListChanged;
        public async Task GetBooks(int pageNo = 1)
        {
            // Отправить запрос http
            var result = await Http.GetAsync(Http.BaseAddress.AbsoluteUri);
            // В случае успешного ответа
            if (result.IsSuccessStatusCode)
            {
                // получить данные из ответа
                var responseData = await result.Content
                .ReadFromJsonAsync<ResponseData<List<Book>>>();
                // обновить параметры страниц
                _currentPage = pageNo;
                _totalPages = (int)Math.Ceiling(responseData.Data.Count() / (double)3);
                // получить нужную страницу
                _books = responseData.Data
                .Skip((pageNo - 1) * 3)
                .Take(3)
                .ToList();
                ListChanged?.Invoke();
            }
            // В случае ошибки
            else
            {
                _books = null;
                _currentPage = 1;
                _totalPages = 0;
            }
        }
    }
}
