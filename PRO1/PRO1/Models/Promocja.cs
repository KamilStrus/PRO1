using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPromocji { get; set; }
        public string Nazwa { get; set; }
        public int PizzaIdPizza { get; set; }
        public int DodatkiIdDodatki { get; set; }
        public int Cena { get; set; }

        public virtual Dodatki DodatkiIdDodatkiNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
