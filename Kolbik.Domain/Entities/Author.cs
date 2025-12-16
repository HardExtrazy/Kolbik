using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolbik.Domain.Entities
{
    public class Author
    {
        [Key]
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
        public string? Nickname { get; set; }
    }
}
