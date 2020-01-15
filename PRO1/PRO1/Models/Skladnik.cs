using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            SkladnikiPizza = new HashSet<SkladnikiPizza>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public int Waga { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<SkladnikiPizza> SkladnikiPizza { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
