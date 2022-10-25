using System;
using System.Collections.Generic;

namespace RestapiDath.Models
{
    public partial class Pelit
    {
        public int PeliId { get; set; }
        public string Nimi { get; set; } = null!;
        public int GenreId { get; set; }
        public int? Julkaisuvuosi { get; set; }
        public string? Tekijä { get; set; }

        public virtual Genret Genre { get; set; } = null!;
    }
}
