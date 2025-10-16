using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorClassLibrary.Domain.Entities
{
    internal class Durka
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ushort Category {  get; set; }
        public ushort NumberWard { get; set; }
        public string Imagine { get; set; }
        public ICollection<Pacient> Pacients { get; set; }
        public Durka() 
        {
            Pacients = new List<Pacient>();
        }

    }
}
