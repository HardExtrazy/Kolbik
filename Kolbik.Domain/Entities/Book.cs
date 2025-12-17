using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kolbik.Domain.Entities
{
    public class Book
    {
        [Key]
        //Id книги
        public int Id { get; set; }
        //Название книги (В случае отсутствия будет пустая строка)
        public string Name { get; set; } = string.Empty;
        //Краткое описание книги (В случае отсутствия будет пустая строка)
        public string Description { get; set; } = string.Empty;
        public string? Image {  get; set; }
        //Рейтинг книги
        public short Rating { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorFullName { get; set; }
        //Id Автора (Вторичный ключ)       
        public Author? Author { get; set; }
    }
}
