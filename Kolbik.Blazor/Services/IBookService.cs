namespace Kolbik.Blazor.Services
{
    public interface IBookService<T> where T : class
    {
        event Action ListChanged;
        // Список объектов
        IEnumerable<T> Books { get; }
        // Номер текущей страницы
        int CurrentPage { get; }
        // Общее количество страниц
        int TotalPages { get; }
        // Получение списка объектов
        Task GetBooks(int pageNo = 1);
    }
}
