using Kolbik.Domain.Entities;
using Kolbik.Domain.Models;

namespace Kolbik.UI.Services
{
    public class MemoryAuthorService : IAuthorService
    {
        static readonly List<Author> authors = [
            new Author
            {   
                Id=1,
                FirstName="Стивен",
                LastName="Кинг",
                Age=78,
                Nickname="Стивен Кинг"
            },
            new Author
            {   
                Id=2,
                FirstName="Александр",
                LastName="Пушкин",
                SureName="Сергеевич",
                Age=37,
                Nickname="Александер Пушкин"
            },
            new Author
            {
                Id=3,
                FirstName="Петр",
                LastName="Капустин",
                SureName="Валерьевич",
                Age=56,
                Nickname="Пророк"
            },
            new Author
            {
                Id=4,
                FirstName="Роман",
                LastName="Пчелкин",
                SureName="Григорьевич",
                Age=25,
                Nickname="Санбой"
            },
            new Author
            {
                Id=5,
                FirstName="Леонид",
                LastName="Минин",
                SureName="Владимирович",
                Age=42,
                Nickname="Шалфей"
            },
            new Author
            {
                Id=6,
                FirstName="Кристина",
                LastName="Адмис",
                SureName="Александровна",
                Age=56,
                Nickname="Кристи"
            },
           ];
          public Task<ResponseData<List<Author>>>  GetAuthorListAsync()
        {
            var result = ResponseData<List<Author>>.OK(authors);
            return Task.FromResult(result);
        }
    }
}
