using System.Text.Json;
using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;

namespace Kolbik.UI.Services
{
    public class ApiBookService(HttpClient httpClient) : IBookService
    {
        public async Task<ResponseData<Book>> CreateBookAsync(Book book, IFormFile? formFile)
        {
            var serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            // Подготовить объект, возвращаемый методом
            var responseData = new ResponseData<Book>();
            // Послать запрос к API для сохранения объекта
            var response = await httpClient.PostAsJsonAsync(httpClient.BaseAddress, book);
            if (!response.IsSuccessStatusCode)
            {
                responseData.Success = false;
                responseData.ErrorMessage = $"Не удалось создать объект:{response.StatusCode}";
                return responseData;
            }
            // Если файл изображения передан клиентом
            if (formFile != null)
            {
                // получить созданный объект из ответа Api-сервиса
                var Book = await response.Content.ReadFromJsonAsync<Book>();
                // создать объект запроса
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{httpClient.BaseAddress.AbsoluteUri}{Book.Id}")
                };
                // Создать контент типа multipart form-data
                var content = new MultipartFormDataContent();
                // создать потоковый контент из переданного файла
                var streamContent = new StreamContent(formFile.OpenReadStream());
                // добавить потоковый контент в общий контент по именем "image"
                content.Add(streamContent, "image", formFile.FileName);
                // поместить контент в запрос
                request.Content = content;
                // послать запрос к Api-сервису
                response = await httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    responseData.Success = false;
                    responseData.ErrorMessage = $"Не удалось сохранить изображение:{response.StatusCode} ";
                }
            }
            return responseData;
        }

        public Task DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseData<Book>> GetBookByIdAsync(int id)
        {
            var apiUrl = $"{httpClient.BaseAddress.AbsoluteUri}{id}";
            var response = await httpClient.GetFromJsonAsync<Book>(apiUrl);
            return new ResponseData<Book>() { Data = response };
        }

        public async Task<ResponseData<List<Book>>> GetBookListAsync(string? author)
        {
            var uri = httpClient.BaseAddress;
            var queryData = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(author))
            {
                queryData.Add("author", author);
            }
            var query = QueryString.Create(queryData);
            var result = await httpClient.GetAsync(uri + query.Value);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ResponseData<List<Book>>>();
            }
            ;
            return ResponseData<List<Book>>.Error("Ошибка чтения API");
        }

        public Task UpdateBookAsync(int id, Book book, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }
}
