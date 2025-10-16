using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorClassLibrary.Domain.Entities
{
    internal class Pacient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DurkaId { get; set; }
        public Durka Durka { get; set; }

    }
}
