using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;

namespace Kolbik.UI.Services
{
    public class ApiAuthorService(HttpClient httpClient): IAuthorService
    {
        public async Task<ResponseData<List<Author>>> GetAuthorListAsync()
        {
            var result = await httpClient.GetAsync(httpClient.BaseAddress);
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadFromJsonAsync<ResponseData<List<Author>>>();
          
            var response = new ResponseData<List<Author>>
            {
                Success = false, ErrorMessage = "Ошибка чтения API"
            };
            return response;
        }
    }
}
