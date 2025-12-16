using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;

namespace Kolbik.UI.Services
{
    public interface IAuthorService
    {
       public Task<ResponseData<List<Author>>> GetAuthorListAsync();
    }
}
