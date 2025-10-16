using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolbik.Domain.Entities
{
    public class Author
    {
        //Id Автора
        public uint Id { get; set; }
        //Имя автоа (В случае отсутствия будет пустая строка)
        public string FirstName { get; set; } = string.Empty;
        //Фамилия автоа (В случае отсутствия будет пустая строка)
        public string LastName { get; set; } = string.Empty;
        //Отчество автора
        public string? SureName { get; set; }
        //Возраст
        public byte Age { get; set; }
        //Путь к фотографии
        public string? PathPhoto {  get; set; }
        //Коллекция книг (В случае отсутствия будет пустой список)
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
