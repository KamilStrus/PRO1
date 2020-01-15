using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Promocja = new HashSet<Promocja>();
            SkladnikiPizza = new HashSet<SkladnikiPizza>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Rozmiar { get; set; }

        public virtual ICollection<Promocja> Promocja { get; set; }
        public virtual ICollection<SkladnikiPizza> SkladnikiPizza { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
