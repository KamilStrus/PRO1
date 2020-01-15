using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public int Kwota { get; set; }
        public string Adres { get; set; }
        public int DodatkiIdDodatki { get; set; }
        public int PromocjaIdPromocji { get; set; }
        public int PizzaIdPizza { get; set; }
        public string SposobPlatnosci { get; set; }
        public int SkladnikIdSkladnik { get; set; }

        public virtual Dodatki DodatkiIdDodatkiNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Promocja PromocjaIdPromocjiNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
