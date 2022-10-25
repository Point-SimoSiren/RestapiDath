using System;
using System.Collections.Generic;

namespace RestapiDath.Models
{
    public partial class Genret
    {
        public Genret()
        {
            
        }

        public int GenreId { get; set; }
        public string Nimi { get; set; } = null!;
        public string? Kuvaus { get; set; }

       
    }
}
