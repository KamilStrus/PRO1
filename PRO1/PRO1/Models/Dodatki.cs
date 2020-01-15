using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Dodatki
    {
        public Dodatki()
        {
            Promocja = new HashSet<Promocja>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdDodatki { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<Promocja> Promocja { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
