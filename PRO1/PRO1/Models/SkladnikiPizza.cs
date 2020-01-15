using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class SkladnikiPizza
    {
        public int SkladnikIdSkladnik { get; set; }
        public int PizzaIdPizza { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
