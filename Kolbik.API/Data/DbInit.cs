using Kolbik.Domain.Entities;

namespace Kolbik.API.Data
{
    public static class DbInit
    {
        public static async Task StupAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var db = scope.ServiceProvider.GetService<AppDbContext>();
            await db.Author.AddRangeAsync([
            new Author
            {
                FirstName="Стивен",
                LastName="Кинг",
                Age=78,
                Nickname="Стивен Кинг"
            },
            new Author
            {
                FirstName="Александр",
                LastName="Пушкин",
                SureName="Сергеевич",
                Age=37,
                Nickname="Александер Пушкин"
            },
            new Author
            {
                FirstName="Петр",
                LastName="Капустин",
                SureName="Валерьевич",
                Age=56,
                Nickname="Пророк"
            },
            new Author
            {
                FirstName="Роман",
                LastName="Пчелкин",
                SureName="Григорьевич",
                Age=25,
                Nickname="Санбой"
            },
            new Author
            {
                FirstName="Леонид",
                LastName="Минин",
                SureName="Владимирович",
                Age=42,
                Nickname="Шалфей"
            },
            new Author
            {
                FirstName="Кристина",
                LastName="Адмис",
                SureName="Александровна",
                Age=56,
                Nickname="Кристи"
            },
           ]);
            await db.SaveChangesAsync();
            await db.Books.AddRangeAsync([
                new Book
                {
                    Id = 1,
                    Name = "Стрелок",
                    Description = "Книга про стрелка Рональда",
                    Rating = 9,
                    Image = "https://localhost:7002/Images/Стрелок.jpg",
                    Author = db.Author.FirstOrDefault(a => a.Id == 1),
                    AuthorId = db.Author.First(c => c.Nickname.Equals("Стивен Кинг"))!.Id
                },
                new Book
                {
                    Id = 2,
                    Name = "Евгений Онегин",
                    Description = "Книга о лишнем человеке",
                    Rating = 7,
                    Image = "https://localhost:7002/Images/Онегин.jpg",
                    Author = db.Author.FirstOrDefault(a => a.Id == 2),
                    AuthorId = db.Author.First(c => c.Nickname.Equals("Александер Пушкин"))!.Id
                },
                 new Book
                {
                    Id = 3,
                    Name = "Остров  в океане",
                    Description = "Книга об одиночестве",
                    Rating = 2,
                    Image = "https://localhost:7002/Images/Остров.jpg",
                    Author = db.Author.FirstOrDefault(a => a.Id == 3),
                    AuthorId = db.Author.First(c => c.Nickname.Equals("Пророк"))!.Id
                },
                  new Book
                {
                    Id = 4,
                    Name = "Что такое денди?",
                    Description = "Руководство о приставке",
                    Rating = 8,
                    Image = "https://localhost:7002/Images/Денди.jpg",
                    Author = db.Author.FirstOrDefault(a => a.Id == 4),
                    AuthorId = db.Author.First(c => c.Nickname.Equals("Санбой"))!.Id
                },
                   new Book
                {
                    Id = 5,
                    Name = "Русские медведи",
                    Description = "Приключение друзей",
                    Rating = 10,
                    Image = "https://localhost:7002/Images/Приключения.jpg",
                    Author = db.Author.FirstOrDefault(a => a.Id == 5),
                    AuthorId = db.Author.First(c => c.Nickname.Equals("Шалфей"))!.Id
                },
                    new Book
                {
                    Id = 6,
                    Name = "Грязный Вилли",
                    Description = "Детектив Дикого Запада",
                    Rating = 4,
                    Image = "https://localhost:7002/Images/Вилли.jpg",
                    Author = db.Author.FirstOrDefault(a => a.Id == 6),
                    AuthorId = db.Author.First(c => c.Nickname.Equals("Кристи"))!.Id
                }
                ]);
            await db.SaveChangesAsync();
        }
    }
}
