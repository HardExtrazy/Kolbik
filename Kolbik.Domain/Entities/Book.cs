using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kolbik.Domain.Entities
{
    public class Book
    {
        //Id книги
        public uint Id { get; set; }
        //Название книги (В случае отсутствия будет пустая строка)
        public string Name { get; set; } = string.Empty;
        //Краткое описание книги (В случае отсутствия будет пустая строка)
        public string Description { get; set; } = string.Empty;
        //Рейтинг книги
        public short Rating { get; set; }
        //Id Автора (Вторичный ключ)
        public uint AuthorId { get; set; }
        //Автор книги (В случае отсутствия будет новый автор)
        public Author? Author { get; set; } = new Author();
    }
}
